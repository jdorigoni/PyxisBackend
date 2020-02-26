using AutoMapper;
using PyxisBackend.Entities.DTO;
using PyxisBackend.Entities.Models;

namespace PyxisBackend.Core.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Pet, PetDTO>();
        }
    }
}
