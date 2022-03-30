using Serivce.Interfaces;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ICatalogContext Context;
        public TestCommandBase()
        {
            Context = OrderContextFactory.Create();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
