using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Windsor.Installer
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using WebAPI.Controllers;
    using DemoWebAPI.Repository;
    using System.Web.Http.Controllers;

    public class WindsorWebApiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
          //  container.Register(Component.For<IMessageSource>().ImplementedBy<HelloWorldMessageSource>().LifestyleScoped());

            // Register all the WebApi controllers within this assembly
            container.Register(

                Component.For<IDatabaseFactory>()
                            .ImplementedBy<DatabaseFactory>()
                            .LifeStyle.PerWebRequest,

                Component.For<IUnitOfWork>()
                            .ImplementedBy<UnitOfWork>()
                            .LifeStyle.PerWebRequest,

                                Types.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient(),

                Types.FromAssemblyNamed("DemoWebAPI.Services")
                            .Where(type => type.Name.EndsWith("Service")).WithServiceAllInterfaces().LifestylePerWebRequest(),

                Types.FromAssemblyNamed("DemoWebAPI.Repository")
                            .Where(type => type.Name.EndsWith("Repository")).WithServiceAllInterfaces().LifestylePerWebRequest()
                                      
                                      );
        }
    }
}