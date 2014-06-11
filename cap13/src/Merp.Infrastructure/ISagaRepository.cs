using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    public interface ISagaRepository
    {
        T GetById<T>(Guid id) where T : Saga;
    }
}
