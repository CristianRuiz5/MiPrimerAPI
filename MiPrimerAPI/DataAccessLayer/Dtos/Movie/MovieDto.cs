using System.ComponentModel.DataAnnotations;

namespace MiPrimerAPI.DataAccessLayer.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la película es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la película no puede exceder los 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria")]
        [MaxLength(10, ErrorMessage = "La clasificación no puede exceder los 10 caracteres")]
        public string Clasification { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
