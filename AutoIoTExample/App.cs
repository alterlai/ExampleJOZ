using AutoIoTExample.Models;
using Microsoft.Extensions.Logging;

namespace AutoIoTExample;
public class App(ILogger<App> _logger)
{
	public async Task RunAsync()
	{
		int x_pos = new Random().Next(0, 1000);
		int y_pos = new Random().Next(0, 1000);

		while(true)
		{
			// simulate some work
			x_pos += new Random().Next(-10, 10);
			y_pos += new Random().Next(-10, 10);

			_logger.LogInformation($"Current position: ({x_pos}, {y_pos}), Operation Mode {ModuleTwin.OperationMode}");

			await Task.Delay(1000); // simulate delay
		}
	}
}
