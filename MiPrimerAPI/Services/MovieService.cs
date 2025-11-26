using MiPrimerAPI.Services.iServices;
using AutoMapper;
using MiPrimerAPI.DataAccessLayer.Dtos.Movie;
using MiPrimerAPI.DataAccessLayer.Models;
using MiPrimerAPI.Repository.iRepository;

namespace MiPrimerAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _movieRepository.MovieExistsByNameAsync(name);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            // Validar si ya existe por nombre
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre de '{movieCreateDto.Name}'");
            }

            // Mapear DTO → Entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);

            // Crear en repositorio
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrió un error al crear la película.");
            }

            // Retornar DTO de la entidad creada
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            // Validar que exista
            var movie = await GetMovieByIdAsync(id);

            var isDeleted = await _movieRepository.DeleteMovieAsync(movie.Id);

            if (!isDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la película.");
            }

            return isDeleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            var existingMovie = await GetMovieByIdAsync(id);

            // Validar nombre duplicado
            var nameExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (nameExists && !string.Equals(existingMovie.Name, dto.Name, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre de '{dto.Name}'");
            }

            // Mapear cambios del DTO sobre la entidad existente
            _mapper.Map(dto, existingMovie);

            var isUpdated = await _movieRepository.UpdateMovieAsync(existingMovie);

            if (!isUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la película.");
            }

            return _mapper.Map<MovieDto>(existingMovie);
        }

        private async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            return movie;
        }
    }
}
