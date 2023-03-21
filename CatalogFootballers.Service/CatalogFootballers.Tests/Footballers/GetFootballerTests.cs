using CatalogFootballers.Data.Models;
using CatalogFootballers.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatalogFootballers.Tests.Footballers
{
    public class GetFootballerTests : TestBase
    {
        [Fact]
        public async Task GetFootballer_Success()
        {
            //Arrange

            //Act
            var footballer = await Context.Footballers.Where(f => f.Id == 3).FirstOrDefaultAsync();

            //Assert
            footballer.ShouldBeOfType<Footballer>();
            footballer.FirstName.ShouldBe("Имя3");
            footballer.LastName.ShouldBe("Фамилия3");
            footballer.Gender.ShouldBe("Пол3");
            footballer.DateOfBirth.ShouldBe(new DateTime(1990, 11, 15));
            footballer.Country.ShouldBe(Country.Италия);
            footballer.TitleCommandId.ShouldBe(3);
        }
    }
}
