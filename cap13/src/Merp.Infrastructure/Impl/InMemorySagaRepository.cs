using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure.Impl
{
    public class InMemorySagaRepository : ISagaRepository
    {
        private static IDictionary<Guid, Saga> runningSagas = new Dictionary<Guid, Saga>();

        public IUnityContainer Container {get; private set;}

        public InMemorySagaRepository(IUnityContainer container)
        {
            if(container==null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        public T GetById<T>(Guid id) where T : Saga
        {
            return runningSagas[id] as T;
        }
    }
}
