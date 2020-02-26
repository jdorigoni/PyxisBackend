using PyxisBackend.Entities.Models;
using System;
using System.Collections.Generic;

namespace PyxisBackend.Contracts.Models
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(Guid personId);
        Person GetPersonWithDetails(Guid personId);
    }
}
