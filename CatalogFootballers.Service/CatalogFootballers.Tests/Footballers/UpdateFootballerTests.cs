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
    public class UpdateFootballerTests : TestBase
    {
        [Fact]
        public async Task UpdateFootballer_Success()
        {
            //Arrange
            var updateFirstName = "update first name";
            //Act
            var footballer = Context.Footballers.FindAsync(CatalogFootballerContextFactory.FootballerIdForUpdate).Result;
            footballer.FirstName = updateFirstName;
            Context.Update(footballer);
            Context.SaveChanges();

            //Assert
            Assert.NotNull(await Context.Footballers.SingleOrDefaultAsync(footballer =>
            footballer.Id == CatalogFootballerContextFactory.FootballerIdForUpdate &&
            footballer.FirstName == updateFirstName));
        }

        [Fact]
        public async Task UpdateFootballer_FailOnWrongId()
        {
            //Arrange
            var footballer = await Context.Footballers.FindAsync(54523);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => Context.Footballers.Update(footballer));
        }
    }
}
