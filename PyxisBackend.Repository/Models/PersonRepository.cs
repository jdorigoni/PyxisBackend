using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.Entities.Models;

namespace PyxisBackend.Repository.Models
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
