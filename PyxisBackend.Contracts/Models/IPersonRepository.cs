using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;

namespace PyxisBackend.Contracts.Models
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(long personId);
        Person GetPersonWithDetails(long personId);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
