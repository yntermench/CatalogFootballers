using CatalogFootballers.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CatalogFootballers.Tests.Footballers
{
    public class DeleteFootballerTests : TestBase
    {
        [Fact]
        public async Task DeleteFootballer_Success()
        {
            //Arrange
            var footballer = await Context.Footballers.FindAsync(CatalogFootballerContextFactory.FootballerIdForDelete);

            //Act
            Context.Footballers.Remove(footballer);
            Context.SaveChanges();

            //Assert
            Assert.Null(Context.Footballers.SingleOrDefault(footballer =>
            footballer.Id == CatalogFootballerContextFactory.FootballerIdForDelete));
        }

        [Fact]
        public async Task DeleteFootballer_FailOnWrongId()
        {
            //Arrange
            var footballer = await Context.Footballers.FindAsync(54523);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => Context.Footballers.Remove(footballer));
        }
    }
}
