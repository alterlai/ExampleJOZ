using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using AutoIoTExample.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace AutoIoTExample;

public class Program
{
	public static async Task Main()
	{
		var builder = Host.CreateApplicationBuilder();

		var isDevelopment = builder.Environment.IsDevelopment();

		if (isDevelopment)
		{
			builder.Services.Configure<ModuleTwin>(builder.Configuration.GetSection("ModuleTwin"));
			builder.Services.AddSingleton<IIotEdgeService<ModuleTwin>, DummyIotService<ModuleTwin>>();
		}
		else
		{
			builder.Services.AddSingleton<IIotEdgeService<ModuleTwin>, IotEdgeService<ModuleTwin>>();
		}

		// Services
		builder.Services.AddHostedService<SetupService>();
		builder.Services.AddSingleton<App>();

		using var host = builder.Build();
		await host.StartAsync();
		var app = host.Services.GetRequiredService<App>();
		await app.RunAsync();
	}
}

