using Microsoft.EntityFrameworkCore;
using MiPrimerAPI.DataAccessLayer.Models;

namespace MiPrimerAPI.DataAccessLayer
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        //Seccion para crear el dbSET de las entidaedes o modelos
        public DbSet<Category> Categories { get; set; }

    }
}
