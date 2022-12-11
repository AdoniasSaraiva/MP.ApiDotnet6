using AutoMapper;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}