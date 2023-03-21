using AutoMapper;
using CatalogFootballers.Data.DTOs;
using CatalogFootballers.Data.Models;

namespace CatalogFootballers.Common.Mappings
{
    public class FootballerMapping : Profile
    {
        public FootballerMapping()
        {
            CreateMap<FootballerDto, Footballer>();
        }
    }
}
