using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Merp.Web.UI.WorkerServices;
using Merp.Infrastructure;
using Merp.Accountancy.CommandStack.Sagas;
using Merp.Accountancy.QueryStack.Model;

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

            //Sagas registration
            Bus.RegisterSaga(() => new FixedPriceJobOrderSaga(container.Resolve<Bus>()));

            //Denormalizers registration
            Bus.RegisterHandler(() => new FixedPriceJobOrderDenormalizer());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<Bus, Bus>();
            container.RegisterType<JobOrderControllerWorkerServices, JobOrderControllerWorkerServices>();
        }
    }
}