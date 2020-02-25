using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.Entities.Models;

namespace PyxisBackend.Repository.Models
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
