using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using Microsoft.Extensions.Logging;

namespace AutoIoTExample;
public class App(ILogger<App> _logger, IIotEdgeService<ModuleTwin> iotEdgeService)
{
	public async Task RunAsync()
	{
		int x_pos = new Random().Next(0, 1000);
		int y_pos = new Random().Next(0, 1000);

		while(true)
		{
			if (Settings.IsRunning)
			{
				// simulate some work
				x_pos += new Random().Next(-10, 10);
				y_pos += new Random().Next(-10, 10);

				_logger.LogInformation($"Current position: ({x_pos}, {y_pos}), Operation Mode {ModuleTwin.OperationMode}");
			}
			else
			{
				_logger.LogInformation("System is not running. Waiting for start command...");
			}

			await Task.Delay(1000); // simulate delay
		}
	}
}
