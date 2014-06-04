using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public class Repository<T> where T : Aggregate
    {
        public void Save(T item)
        {

        }

        public T GetById(Guid id)
        {
            return default(T);
        }
    }
}
