using System;

namespace PyxisBackend.Entities.DTO
{
    public class PetDTO
    {
        public long PetId { get; set; }
        public string PetName { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }
    }
}
