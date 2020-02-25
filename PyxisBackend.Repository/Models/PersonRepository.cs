using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.Entities.Models;
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
    }
}
