using System;
using System.Collections.Generic;

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
}
