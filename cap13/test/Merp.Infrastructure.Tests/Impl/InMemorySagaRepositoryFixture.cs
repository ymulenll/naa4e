using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;
using Merp.Infrastructure.Impl;

namespace Merp.Infrastructure.Tests.Impl
{
    [TestClass]
    public class InMemorySagaRepositoryFixture
    {
        [TestMethod]
        public void Ctor_should_throw_ArgumentNullException_on_null_container_and_value_of_parameter_should_be_container()
        {
            Executing.This(() => new InMemorySagaRepository(null))
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
}
