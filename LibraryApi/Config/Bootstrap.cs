using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LibraryApi.Config
{
	public static class Bootstrap
	{
		public static void Configure(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute("LibraryApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
		}
	}
}
