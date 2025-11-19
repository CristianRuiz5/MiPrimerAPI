using System.ComponentModel.DataAnnotations;

namespace MiPrimerAPI.DataAccessLayer.Dtos.Category

{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede exceder los 100 caracteres")]
        public string Name { get; set; }
    }
}
