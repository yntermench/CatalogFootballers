using CatalogFootballers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFootballers.Tests.Common
{
    public abstract class TestBase : IDisposable
    {
        protected readonly CatalogFootballersDbContext Context;

        public TestBase()
        {
            Context = CatalogFootballerContextFactory.Create();
        }

        public void Dispose()
        {
            CatalogFootballerContextFactory.Destroy(Context);
        }
    }
}
