using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using LibraryApi.Config;

namespace Hoster
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new HttpSelfHostConfiguration(new Uri("http://localhost:8080"));
			Bootstrap.Configure(config);
			var server = new HttpSelfHostServer(config);

			server.OpenAsync().Wait();
			Console.WriteLine("Your Server is waiting at {0}", config.BaseAddress);
			Console.ReadLine();
			server.CloseAsync().Wait();
		}
	}
}
