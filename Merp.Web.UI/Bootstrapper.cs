using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using Merp.Web.UI.WorkerServices;
using Merp.Infrastructure;
using Merp.Accountancy.CommandStack.Sagas;

namespace Merp.Web.UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Container { get; private set; }

        public static void Initialise()
        {
            Bus.RegisterSaga(() => new JobOrderLifetimeManager());
            
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            Container = container;
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