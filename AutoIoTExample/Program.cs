using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace AutoIoTExample;

public class Program
{
	public static async Task Main()
	{
		var builder = Host.CreateApplicationBuilder();

		// Services
		builder.Services.AddSingleton<App>();

		using var host = builder.Build();
		var app = host.Services.GetRequiredService<App>();
		await app.RunAsync();
		await host.WaitForShutdownAsync();
	}
}

