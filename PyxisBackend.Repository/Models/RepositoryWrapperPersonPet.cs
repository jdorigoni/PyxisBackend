using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;

namespace PyxisBackend.Repository.Models
{
    public class RepositoryWrapperPersonPet : IRepositoryWrapperPersonPet
    {
        private readonly RepositoryContext _repositoryContext;
        private IPersonRepository _person;
        private IPetRepository _pet;

        public IPersonRepository Person 
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_repositoryContext);
                }
                return _person;
            }
        }

        public IPetRepository Pet
        {
            get
            {
                if (_pet == null)
                {
                    _pet = new PetRepository(_repositoryContext);
                }
                return _pet;
            }
        }

        public RepositoryWrapperPersonPet(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
