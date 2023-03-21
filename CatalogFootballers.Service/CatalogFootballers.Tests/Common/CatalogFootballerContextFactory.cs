using CatalogFootballers.Data;
using CatalogFootballers.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFootballers.Tests.Common
{
    public class CatalogFootballerContextFactory
    {
        public static int FootballerIdForDelete = 1;
        public static int FootballerIdForUpdate = 2;

        public static CatalogFootballersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CatalogFootballersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CatalogFootballersDbContext(options);
            context.Database.EnsureCreated();
            context.TitlesCommands.AddRange(
                new TitleCommand
                {
                    Title = "Команда1"
                },
                new TitleCommand
                {
                    Title = "Команда2"
                },
                new TitleCommand
                {
                    Title = "Команда3"
                }
                );
            context.Footballers.AddRange(
                new Footballer
                {
                    FirstName = "Имя1",
                    LastName = "Фамилия1",
                    Gender = "Пол1",
                    DateOfBirth = new DateTime(2000,05,22),
                    Country = Country.Россия,
                    TitleCommandId = 2
                },
                new Footballer
                {
                    FirstName = "Имя2",
                    LastName = "Фамилия2",
                    Gender = "Пол2",
                    DateOfBirth = new DateTime(1995, 07, 11),
                    Country = Country.США,
                    TitleCommandId = 1
                },
                new Footballer
                {
                    FirstName = "Имя3",
                    LastName = "Фамилия3",
                    Gender = "Пол3",
                    DateOfBirth = new DateTime(1990, 11, 15),
                    Country = Country.Италия,
                    TitleCommandId = 3
                },
                new Footballer
                {
                    FirstName = "Имя4",
                    LastName = "Фамилия4",
                    Gender = "Пол4",
                    DateOfBirth = new DateTime(1994, 03, 02),
                    Country = Country.Россия,
                    TitleCommandId = 2
                }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(CatalogFootballersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
