using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using Memento.Persistence;
using Merp.Registry.QueryStack;
using Merp.Web.Site.Areas.Registry.WorkerServices;
using Memento.Messaging.Postie;

namespace Merp.Web.Site.Tests.Areas.Registry.WorkerServices
{
    [TestClass]
    public class PersonControllerWorkerServicesFixture
    {
        [TestMethod]
        public void Ctor_should_throw_ArgumentNullException_on_null_Bus_parameter()
        {
            var database = new Mock<IDatabase>().Object;
            var repository = new Mock<IRepository>().Object;
            Executing.This(() => new PersonControllerWorkerServices(null, database, repository))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("bus");
        }

        [TestMethod]
        public void Ctor_should_throw_ArgumentNullException_on_null_database_parameter()
        {
            var bus = new Mock<IBus>().Object;
            var repository = new Mock<IRepository>().Object;
            Executing.This(() => new PersonControllerWorkerServices(bus, null, repository))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("database");
        }

        [TestMethod]
        public void Ctor_should_throw_ArgumentNullException_on_null_repository_parameter()
        {
            var bus = new Mock<IBus>().Object;
            var database = new Mock<IDatabase>().Object;
            Executing.This(() => new PersonControllerWorkerServices(bus, database, null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("repository");
        }

        [TestMethod]
        public void Ctor_should_set_Bus_property()
        {
            var bus = new Mock<IBus>().Object;
            var database = new Mock<IDatabase>().Object;
            var repository = new Mock<IRepository>().Object;
            var sut = new PersonControllerWorkerServices(bus, database, repository);
            Assert.AreSame(bus, sut.Bus);
        }

        [TestMethod]
        public void Ctor_should_set_Database_property()
        {
            var bus = new Mock<IBus>().Object;
            var database = new Mock<IDatabase>().Object;
            var repository = new Mock<IRepository>().Object;
            var sut = new PersonControllerWorkerServices(bus, database, repository);
            Assert.AreSame(database, sut.Database);
        }

        [TestMethod]
        public void Ctor_should_set_Repository_property()
        {
            var bus = new Mock<IBus>().Object;
            var database = new Mock<IDatabase>().Object;
            var repository = new Mock<IRepository>().Object;
            var sut = new PersonControllerWorkerServices(bus, database, repository);
            Assert.AreSame(repository, sut.Repository);
        }
    }
}
