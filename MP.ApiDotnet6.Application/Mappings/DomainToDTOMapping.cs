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
            CreateMap<Purchase, PurchaseDetailsDTO>()
                     .ForMember(x => x.Person, opt => opt.Ignore())
                     .ForMember(x => x.Product, opt => opt.Ignore())
                     .ConstructUsing((model, context) =>
                     {
                         var dto = new PurchaseDetailsDTO
                         {
                             Product = model.Product.Name,
                             Id = model.Id,
                             Person = model.Person.Name,
                             Date = model.Date
                         };
                         return dto;
                     });
        }
    }
}