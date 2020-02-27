using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PyxisBackend.Entities.DTO
{
    public class PersonDTO
    {
        public long PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonEmail { get; set; }
        public string PersonPassword { get; set; }
        public IEnumerable<PetDTO> Pets { get; set; }
    }

    public class PersonForCreateUpdateDTO
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(100, ErrorMessage = "El Nombre no puede ser mayor a 100 caracteres")]
        public string PersonName { get; set; }


        [Required(ErrorMessage = "El Email es requerido")]
        [StringLength(100, ErrorMessage = "El Email no puede ser mayor a 100 caracteres")]
        public string PersonEmail { get; set; }

        [Required(ErrorMessage = "La Clave es requerida")]
        [StringLength(100, ErrorMessage = "La Clave no puede ser mayor a 100 caracteres")]
        public string PersonPassword { get; set; }
    }

}
