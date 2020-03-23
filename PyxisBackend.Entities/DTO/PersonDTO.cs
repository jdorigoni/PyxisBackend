﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PyxisBackend.Entities.DTO
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<PetDTO> Pets { get; set; }
    }

    public class PersonForCreateUpdateDTO
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50, ErrorMessage = "El Nombre no puede ser mayor a 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(50, ErrorMessage = "El Apellido no puede ser mayor a 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [StringLength(50, ErrorMessage = "El Email no puede ser mayor a 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Clave es requerida")]
        [StringLength(100, ErrorMessage = "La Clave no puede ser mayor a 100 caracteres")]
        public string Password { get; set; }
    }

}
