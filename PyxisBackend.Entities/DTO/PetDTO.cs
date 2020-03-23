using System;
using System.ComponentModel.DataAnnotations;

namespace PyxisBackend.Entities.DTO
{
    public class PetDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }
    }

    public class PetForCreateUpdateDTO
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50, ErrorMessage = "El Nombre no puede ser mayor a 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El tipo de Animale es requerido")]
        [StringLength(50, ErrorMessage = "El tipo de Animal no puede ser mayor a 50 caracteres")]
        public string AnimalType { get; set; }

        [Required(ErrorMessage = "La Raza es requerida")]
        [StringLength(50, ErrorMessage = "La Raza no puede ser mayor a 50 caracteres")]
        public string Breed { get; set; }
    }
}
