using Microsoft.EntityFrameworkCore;
using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PyxisBackend.Repository.Models
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return FindAll()
                  .OrderBy(per => per.PersonName)
                  .ToList(); 
        }

        public Person GetPersonById(long personId)
        {
            return FindByCondition(person => person.PersonId.Equals(personId))
                  .FirstOrDefault();
        }

        public Person GetPersonWithDetails(long personId)
        {
            return FindByCondition(person => person.PersonId.Equals(personId))
                  .Include(pet => pet.Pets)
                  .FirstOrDefault();
        }
    }
}
