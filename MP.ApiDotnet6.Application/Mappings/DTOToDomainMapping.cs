using AutoMapper;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Application.Mappings
{
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping() 
        { 
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
