using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PyxisBackend.Entities.Models
{
    [Table("pets")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50, ErrorMessage = "El Nombre no puede ser mayor a 50 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "El tipo de Animal es requerido.")]
        [StringLength(50, ErrorMessage = "El tipo de Animal no puede ser mayor a 50 caracteres")]
        public string AnimalType { get; set; }
        
        [Required(ErrorMessage = "La Raza del animal es requerida.")]
        [StringLength(50, ErrorMessage = "La raza del Animal no puede ser mayor a 50 caracteres")]
        public string Breed { get; set; }

        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
