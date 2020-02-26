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
        public long PetId { get; set; }

        public string PetName { get; set; }
        
        [Required(ErrorMessage = "El tipo de Animal es requerido.")]
        public string AnimalType { get; set; }
        
        [Required(ErrorMessage = "La Raza del animal es requerida.")]
        public string Breed { get; set; }

        [ForeignKey(nameof(Person))]
        public Guid PersonId { get; set; }

        public Person Person { get; set; }
    }
}
