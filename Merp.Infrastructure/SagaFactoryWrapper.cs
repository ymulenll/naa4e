using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Infrastructure
{
    abstract class SagaFactoryWrapper
    {
        public abstract bool Handles<TE>();
        public abstract IHandleMessage<TE> CreateInstance<TE>() where TE : Message;
    }

    class SagaFactoryWrapper<T> : SagaFactoryWrapper
    {
        private readonly Func<T> factory;

        public SagaFactoryWrapper(Func<T> factory)
        {
            this.factory = factory;
        }

        public override bool Handles<TE>()
        {
            return typeof(IHandleMessage<TE>).IsAssignableFrom(typeof(T));
        }

        public override IHandleMessage<TE> CreateInstance<TE>()
        {
            return (IHandleMessage<TE>)factory(); ;
        }
    }
}
