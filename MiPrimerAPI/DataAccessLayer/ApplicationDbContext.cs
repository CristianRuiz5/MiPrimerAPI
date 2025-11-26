using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.DataAccessLayer.Models;
namespace MiPrimerAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Definir los DbSets (tablas) que voy a utilizar en mi aplicaciòn
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
