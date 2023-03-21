using AutoMapper;
using CatalogFootballers.Data;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogFootballers.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        protected CatalogFootballersDbContext _context;
        protected IMapper _mapper;

        public BaseController(CatalogFootballersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseController() { }
    }
}
