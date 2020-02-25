using PyxisBackend.Entities.Models;
using System.Collections.Generic;

namespace PyxisBackend.Contracts.Models
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> GetAllPersons();
    }
}
