using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.DataAccessLayer.Models;

namespace MiPrimerAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        //constructor: para poder inicializar la clase base DbContext en otras palabras, virtualizar mi BD
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Definir los DbSets (tablas) que voy a utilizar en mi aplicaciòn
        public DbSet<Category> Categories { get; set; }
    }
}
