using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();
            //ToDoo: az .AS azt mondja, hogy azt a tipust amelyt előtte én akarom használni, akkor az .AS<>-ben lévő tipussal ovverradoljam.
            //Tehát a Controller.cs konstruktorban IRestaurantData fog müködni.  IRestaurantData res = new InMemoryRestaurantData();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}