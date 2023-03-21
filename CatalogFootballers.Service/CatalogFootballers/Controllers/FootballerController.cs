using AutoMapper;
using CatalogFootballers.Data;
using CatalogFootballers.Data.DTOs;
using CatalogFootballers.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogFootballers.Controllers
{
    public class FootballerController : BaseController
    {
        public FootballerController(CatalogFootballersDbContext context, IMapper mapper) : base(context, mapper) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetAll()
        {
            var footballers = await _context.Footballers
                .Include(ft => ft.TitleCommand)
                .ToListAsync();
            return Ok(footballers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var footballer = await _context.Footballers
                .Include(ft => ft.TitleCommand)
                .FirstOrDefaultAsync(ft => ft.Id == id);
            if (footballer == null)
            {
                return NotFound();
            }
            return Ok(footballer);
        }
        [HttpPost]
        public async Task<ActionResult<Footballer>> Create([FromBody]FootballerDto footballerDto)
        {
            var footballer = _mapper.Map<Footballer>(footballerDto);
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();

            return Ok(footballer);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Footballer>> Edit([FromBody]FootballerDto footballerDto)
        {
            if (footballerDto.Id <= 0)
            {
                return BadRequest();
            }

            var footballer = _context.Footballers
                .FirstOrDefaultAsync(ft => ft.Id == footballerDto.Id).Result;

            if (footballer == null)
            {
                return NotFound();
            }

            footballer.FirstName = footballerDto.FirstName;
            footballer.LastName = footballerDto.LastName;
            footballer.DateOfBirth = footballerDto.DateOfBirth;
            footballer.Country = footballerDto.Country;
            footballer.Gender = footballerDto.Gender;
            footballer.TitleCommandId = footballerDto.TitleCommandId;
            footballer.TitleCommand = footballerDto.TitleCommand;

            _context.Footballers.Update(footballer);

            await _context.SaveChangesAsync();

            return Ok(footballer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Footballer>> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var footballer = await _context.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return BadRequest();
            }

            _context.Footballers.Remove(footballer);

            await _context.SaveChangesAsync();

            return Ok(footballer);
        }
    }
}