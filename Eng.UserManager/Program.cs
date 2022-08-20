using Microsoft.AspNetCore;

namespace Eng.UserManager.WebApi
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
				WebHost.CreateDefaultBuilder(args)
					.UseStartup<Startup>()
					.ConfigureLogging(logging =>
					{
						logging.ClearProviders();
						logging.AddConsole();
						logging.SetMinimumLevel(LogLevel.Trace);
					})
					.Build();
	}
}
