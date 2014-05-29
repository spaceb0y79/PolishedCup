using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions;
using Ninject;
using Ninject.Extensions.Conventions;
using System.Reflection;
using PolishedCup.Services;

namespace PolishedCup.App_Start
{
    public class BindingModule : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(x => x
            // .FromAssembliesMatching("PolishedCup.Services.*")
            // .SelectAllClasses()
            // .BindDefaultInterface() //prefixed I with classname.  
            // );

            //Kernel.Bind(x => x
            //    .FromAssembliesMatching("PolishedCup.Services.*")
            //    .SelectAllClasses()
            //    .BindDefaultInterface()
            //    );
            Bind<IGolferService>().To<GolferService>();
            Bind<ISessionService>().To<SessionService>();
        }
    }

}