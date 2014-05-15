using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LibraryApi.Model;
using Microsoft.Practices.Unity;
using WebApiContrib.IoC.Unity;

namespace LibraryApi.Config
{
	public static class Bootstrap
	{
		public static void Configure(HttpConfiguration config)
		{
			var container = new UnityContainer();
			container.RegisterType<ILoanCommands, LibraryEf>();
			container.RegisterType<IBookQueries, LibraryEf>();

			config.DependencyResolver = new UnityResolver(container);

			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute("HomePage", "api", new {controller = "Home"});
			config.Routes.MapHttpRoute("LibraryApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
		}
	}
}
