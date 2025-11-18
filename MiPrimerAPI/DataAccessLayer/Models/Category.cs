using System.ComponentModel.DataAnnotations;

namespace MiPrimerAPI.DataAccessLayer.Models
{
    public class Category : AuditBase

    {
        [Required] //Este data annotatiopn indica que el campo es obligatorio
        [Display(Name="Nombre de la categoria")]//Me sirve para personalizar el nombre que se muestra en las vistas o mensajes de error
        public string Name { get; set; }

    }
}

////*
// * Categories
// * --Id
// * --Name
// * --CreatedDate
// * --ModifiedDate