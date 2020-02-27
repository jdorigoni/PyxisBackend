using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;

namespace PyxisBackend.Contracts.Models
{
    public interface IPetRepository : IRepositoryBase<Pet>
    {
        IEnumerable<Pet> GetAllPets();
        Pet GetPetById(long petId);
        IEnumerable<Pet> PetsByPerson(long personId);
    }
}
