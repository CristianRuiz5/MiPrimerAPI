using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.APIMapper;
using MiPrimerAPI.DataAccessLayer;
using MiPrimerAPI.Repository;
using MiPrimerAPI.Repository.iRepository;
using MiPrimerAPI.Services;
using MiPrimerAPI.Services.iServices;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Mappers>());

//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


//Movies

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();








builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
