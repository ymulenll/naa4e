using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Merp.Web.UI.WorkerServices;
using Merp.Infrastructure;
using Merp.Accountancy.CommandStack.Sagas;
using Merp.Accountancy.QueryStack.Model;
using Merp.Infrastructure.Impl;

namespace Merp.Web.UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Container { get; private set; }

        public static void Initialise()
        {   
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            Container = container;
            RegisterSagas();
            RegisterHandlers();
        }

        private static void RegisterHandlers()
        {
            var bus = Container.Resolve<IBus>();
            bus.RegisterHandler<FixedPriceJobOrderDenormalizer>();
        }

        private static void RegisterSagas()
        {
            ////Sagas registration
            //Bus.RegisterSaga(() => new FixedPriceJobOrderSaga(container.Resolve<Bus>()));

            ////Denormalizers registration
            //Bus.RegisterHandler(() => new FixedPriceJobOrderDenormalizer());
            
            var bus = Container.Resolve<IBus>();
            bus.RegisterSaga<FixedPriceJobOrderSaga>();  
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();   
            container.RegisterType<IBus, InMemoryBus>(new InjectionConstructor(container));
            container.RegisterType<JobOrderControllerWorkerServices, JobOrderControllerWorkerServices>();
        }
    }
}