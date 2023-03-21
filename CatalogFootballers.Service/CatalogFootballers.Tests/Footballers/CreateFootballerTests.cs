using CatalogFootballers.Data.Models;
using CatalogFootballers.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatalogFootballers.Tests.Footballers
{
    public class CreateFootballerTests : TestBase
    {
        [Fact]
        public async Task CreateFootballer_Success()
        {
            //Arrange
            var footballerFirstName = "footballer first name";
            var footballerLastName = "footballer last name";
            var footballerGender = "gender footballer";
            var footballerDateOfBirth = DateTime.UtcNow;
            var footballerCountry = Country.Россия;
            var footballerTitleCommandId = 2;

            //Act
            var footballerId = await Context.Footballers.AddAsync(new Footballer
            {
                FirstName = footballerFirstName,
                LastName = footballerLastName,
                Gender = footballerGender,
                DateOfBirth = footballerDateOfBirth,
                Country = footballerCountry,
                TitleCommandId = footballerTitleCommandId
            });
            await Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(await Context.Footballers.SingleOrDefaultAsync(footballer =>
                footballer.Id == footballerId.Entity.Id && footballer.FirstName == footballerFirstName
                && footballer.LastName == footballerLastName && footballer.Gender == footballerGender
                && footballer.DateOfBirth == footballerDateOfBirth && footballer.Country == footballerCountry
                && footballer.TitleCommandId == footballerTitleCommandId));
        }
    }
}
