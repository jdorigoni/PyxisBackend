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
            try
            {
                return FindAll()
                  .OrderBy(per => per.LastName)
                  .ToList();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public Person GetPersonById(long personId)
        {
            try
            {
                return FindByCondition(person => person.Id.Equals(personId))
                  .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public Person GetPersonWithDetails(long personId)
        {
            try
            {
                return FindByCondition(person => person.Id.Equals(personId))
                      .Include(pet => pet.Pets)
                      .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreatePerson(Person person)
        {
            try
            {
                Create(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void UpdatePerson(Person person)
        {
            try
            {
                Update(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletePerson(Person person)
        {
            try
            {
                Delete(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
