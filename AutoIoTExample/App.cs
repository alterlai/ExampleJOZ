using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AutoIoTExample;
public class App(IIotEdgeService<ModuleTwin> edgeService, ILogger<App> _logger)
{
	public async Task RunAsync()
	{
		// ModuleTwinUpdated callback.
		edgeService.ModuleTwinUpdated += OnTwinUpdated;

		
		int x_pos = new Random().Next(0, 100);
		int y_pos = new Random().Next(0, 100);

		while (true)
		{
			if(Settings.IsTurnedOn)
			{
				// Simulate some work
				x_pos += new Random().Next(-1, 2); // Randomly adjust x position
				y_pos += new Random().Next(-1, 2); // Randomly adjust y position

				_logger.LogInformation($"Current position: X:{x_pos}, Y:{y_pos}. Operating mode: {ModuleTwin.OperatingMode}");
			}
			else
			{
				_logger.LogInformation("Module is turned off. No operations will be performed.");
			}
				await Task.Delay(1000);
		}
	}

	private void OnTwinUpdated(object? sender, ModuleTwin twin)
	{
		// Handle twin update
		_logger.LogInformation($"Module twin has updated. New operating mode = {ModuleTwin.OperatingMode}");
	}
}
