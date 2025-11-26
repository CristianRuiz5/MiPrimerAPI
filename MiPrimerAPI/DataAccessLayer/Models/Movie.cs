using System.ComponentModel.DataAnnotations;

namespace MiPrimerAPI.DataAccessLayer.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre de la película")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Duración (minutos)")]
        public int Duration { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Clasificación")]
        public string Clasification { get; set; }
    }
}
