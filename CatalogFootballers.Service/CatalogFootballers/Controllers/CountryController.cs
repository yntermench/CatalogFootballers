using AutoMapper;
using CatalogFootballers.Data;
using CatalogFootballers.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogFootballers.Controllers
{
    public class CountryController : BaseController
    {
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var enumValues = Enum.GetValues(typeof(Country))
            .Cast<Enum>()
            .Select(e => new { key = e.ToString(), value = Convert.ToInt32(e) })
            .ToList();

            return Ok(enumValues);
        }
    }
}
