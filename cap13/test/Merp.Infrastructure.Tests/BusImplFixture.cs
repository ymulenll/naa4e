using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
 
namespace Merp.Infrastructure.Tests
{
    [TestClass]
    public class BusImplFixture
    {
        [TestMethod]
        public void RegisterSaga_should_throw_InvalidOperationException_on_type_arguments_that_do_not_implement_IAmStartedBy_interface()
        {
            IBus bus = new BusImpl();
            Executing.This(() => bus.RegisterSaga<PretendingSaga>())
                .Should()
                .Throw<InvalidOperationException>();   
        }

        [TestMethod]
        public void RegisterSaga_should_throw_InvalidOperationException_sagas_that_implements_IAmStartedBy_more_than_once()
        {
            IBus bus = new BusImpl();
            Executing.This(() => bus.RegisterSaga<OverloadedSaga>())
                .Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void RegisterSaga_should_not_throw_InvalidOperationException_on_type_arguments_that_implement_IAmStartedBy_interface()
        {
            IBus bus = new BusImpl();
            bus.RegisterSaga<DummySaga>(); 
        }

        public class PretendingSaga : Saga
        {
            protected override void ConfigureSagaMappings()
            {
                
            }
        }

        public class DummySaga : Saga, 
            IAmStartedBy<DummySaga.DummyMessage>
        {
            public class DummyMessage : Message
            {

            }

            protected override void ConfigureSagaMappings()
            {
                throw new NotSupportedException();
            }

            public void Handle(DummySaga.DummyMessage message)
            {
                throw new NotSupportedException();
            }
        }

        public class OverloadedSaga : Saga,
            IAmStartedBy<OverloadedSaga.FooMessage>,
            IAmStartedBy<OverloadedSaga.BarMessage>
        {
            public class FooMessage : Message
            {

            }
            public class BarMessage : Message
            {

            }

            protected override void ConfigureSagaMappings()
            {
                throw new NotSupportedException();
            }

            public void Handle(OverloadedSaga.BarMessage message)
            {
                throw new NotImplementedException();
            }

            public void Handle(OverloadedSaga.FooMessage message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
