using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyxisBackend.Entities.Models
{
    [Table("persons")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50, ErrorMessage ="El Nombre no puede ser mayor a 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(50, ErrorMessage = "El Apellido no puede ser mayor a 50 caracteres")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "El Email es requerido")]
        [StringLength(50, ErrorMessage = "El Email no puede ser mayor a 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Clave es requerida")]
        [StringLength(100, ErrorMessage = "La Clave no puede ser mayor a 100 caracteres")]
        public string Password { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
