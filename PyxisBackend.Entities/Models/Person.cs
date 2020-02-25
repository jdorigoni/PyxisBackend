using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyxisBackend.Entities.Models
{
    [Table("persons")]
    public class Person
    {
        public Guid PersonId { get; set; }
        
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(100, ErrorMessage ="El Nombre no puede ser mayor a 100 caracteres")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [StringLength(100, ErrorMessage = "El Email no puede ser mayor a 100 caracteres")]
        public string PersonEmail { get; set; }

        [Required(ErrorMessage = "La Clave es requerida")]
        [StringLength(100, ErrorMessage = "La Clave no puede ser mayor a 100 caracteres")]
        public string PersonPassword { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
