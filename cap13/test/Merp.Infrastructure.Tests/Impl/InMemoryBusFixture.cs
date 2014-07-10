using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using Microsoft.Practices.Unity;
using Merp.Infrastructure.Impl;

namespace Merp.Infrastructure.Tests.Impl
{
    [TestClass]
    public class InMemoryBusFixture
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void Ctor_should_throw_ArgumentNullException_on_null_container_and_value_of_parameter_should_be_container()
            {
                Executing.This(() => new InMemoryBus(null))
                               .Should()
                               .Throw<ArgumentNullException>()
                               .And
                               .ValueOf
                               .ParamName
                               .Should()
                               .Be
                               .EqualTo("container");
            }
        }

        [TestClass]
        public class RegisterSagaMethod
        {
            [TestMethod]
            public void RegisterSaga_should_throw_InvalidOperationException_on_type_arguments_that_do_not_implement_IAmStartedBy_interface()
            {
                var containerMock = new Mock<IUnityContainer>().Object;
                IBus bus = new InMemoryBus(containerMock);
                Executing.This(() => bus.RegisterSaga<PretendingSaga>())
                    .Should()
                    .Throw<InvalidOperationException>();   
            }

            [TestMethod]
            public void RegisterSaga_should_throw_InvalidOperationException_sagas_that_implements_IAmStartedBy_more_than_once()
            {
                var containerMock = new Mock<IUnityContainer>().Object;
                IBus bus = new InMemoryBus(containerMock);
                Executing.This(() => bus.RegisterSaga<OverloadedSaga>())
                    .Should()
                    .Throw<InvalidOperationException>();
            }

            [TestMethod]
            public void RegisterSaga_should_not_throw_InvalidOperationException_on_type_arguments_that_implement_IAmStartedBy_interface()
            {
                var containerMock = new Mock<IUnityContainer>().Object;
                IBus bus = new InMemoryBus(containerMock);
                bus.RegisterSaga<DummySaga>(); 
            }

            public class PretendingSaga : Saga
            {
                public PretendingSaga(IBus bus, IEventStore eventStore)
                    : base(bus, eventStore)
                {

                }

            }

            public class DummySaga : Saga,
                IAmStartedBy<DummySaga.DummyMessage>
            {
                public class DummyMessage : Message
                {

                }

                public DummySaga(IBus bus, IEventStore eventStore)
                    : base(bus, eventStore)
                {

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

                public OverloadedSaga(IBus bus, IEventStore eventStore)
                    : base(bus, eventStore)
                {

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

        [TestClass]
        public class SendMethod
        {
            [TestMethod]
            public void Send()
            {
                var command = new InMemoryBusFixture.SendMethod.FakeSaga.StartCommand();
                var containerMock = new Mock<IUnityContainer>().Object;
                IBus bus = new InMemoryBus(containerMock);
                bus.RegisterSaga<FakeSaga>();
                bus.Send(command);
            }

            public class FakeSaga : Saga, IAmStartedBy<InMemoryBusFixture.SendMethod.FakeSaga.StartCommand>
            {
                public FakeSaga(IBus bus, IEventStore eventStore)
                    : base(bus, eventStore) { }

                public void Handle(FakeSaga.StartCommand message)
                {
                    
                }

                public class StartCommand : Command
                {

                }
            }
        }
    }
}
