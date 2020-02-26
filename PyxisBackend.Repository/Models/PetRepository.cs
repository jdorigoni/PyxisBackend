using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PyxisBackend.Repository.Models
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return FindAll()
                  .OrderBy(pet => pet.PetName)
                  .ToList();
        }

        public Pet GetPetById(long petId)
        {
            return FindByCondition(pet => pet.PetId.Equals(petId))
                  .FirstOrDefault();
        }
    }
}
