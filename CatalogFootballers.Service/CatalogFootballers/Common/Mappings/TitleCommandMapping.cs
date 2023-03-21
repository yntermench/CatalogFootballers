using AutoMapper;
using CatalogFootballers.Data.DTOs;
using CatalogFootballers.Data.Models;

namespace CatalogFootballers.Common.Mappings
{
    public class TitleCommandMapping : Profile
    {
        public TitleCommandMapping()
        {
            CreateMap<TitleCommandDto, TitleCommand>();
        }
    }
}
