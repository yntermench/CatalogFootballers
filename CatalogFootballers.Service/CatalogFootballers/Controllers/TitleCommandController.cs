using AutoMapper;
using CatalogFootballers.Data;
using CatalogFootballers.Data.DTOs;
using CatalogFootballers.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogFootballers.Controllers
{
    public class TitleCommandController : BaseController
    {
        public TitleCommandController(CatalogFootballersDbContext context, IMapper mapper) : base(context, mapper) { }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitleCommand>>> GetAll()
        {
            var titlesCommands = await _context.TitlesCommands
                .ToListAsync();
            return Ok(titlesCommands);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleCommand>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var titleCommand = await _context.TitlesCommands
                .FirstOrDefaultAsync(ft => ft.Id == id);
            if (titleCommand == null)
            {
                return NotFound();
            }
            return Ok(titleCommand);
        }
        [HttpPost]
        public async Task<ActionResult<TitleCommand>> Create([FromBody] TitleCommandDto titleCommandDto)
        {
            var titleCommand = _mapper.Map<TitleCommand>(titleCommandDto);
            _context.TitlesCommands.Add(titleCommand);
            await _context.SaveChangesAsync();

            return Ok(titleCommand);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TitleCommand>> Edit([FromBody] TitleCommandDto titleCommandDto)
        {
            if (titleCommandDto.Id <= 0)
            {
                return BadRequest();
            }

            var titleCommand = _context.TitlesCommands
                .FirstOrDefaultAsync(ft => ft.Id == titleCommandDto.Id).Result;

            if (titleCommand == null)
            {
                return NotFound();
            }

            titleCommand.Title = titleCommand.Title;

            _context.TitlesCommands.Update(titleCommand);

            await _context.SaveChangesAsync();

            return Ok(titleCommand);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitleCommand>> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var titleCommand = await _context.TitlesCommands.FindAsync(id);
            if (titleCommand == null)
            {
                return BadRequest();
            }

            _context.TitlesCommands.Remove(titleCommand);

            await _context.SaveChangesAsync();

            return Ok(titleCommand);
        }
    }
}
