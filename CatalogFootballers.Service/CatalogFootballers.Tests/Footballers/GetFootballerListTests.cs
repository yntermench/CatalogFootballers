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
    public class GetFootballerListTests : TestBase
    {
        [Fact]
        public void GetFootballerList_Success()
        {
            //Arrange
            var footballers = Context.Footballers;

            //Act

            //Assert
            footballers.Count().ShouldBe(4);
        }
    }
}
