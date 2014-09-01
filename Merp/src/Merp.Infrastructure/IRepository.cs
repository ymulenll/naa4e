using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;

namespace Merp.Infrastructure
{
    public interface IRepository 
    {
        T GetById<T>(Guid id) where T : IAggregate;
        T GetById<T, K>(Guid id) 
            where T : IAggregate
            where K : AbstractIndexCreationTask, new();
        void Save<T>(T item) where T : IAggregate;
    }
}
