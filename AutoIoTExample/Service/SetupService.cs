using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoIoTExample.Service;
public class SetupService(IIotEdgeService<ModuleTwin> iotEdgeService ) : IHostedService
{
	public Task StartAsync(CancellationToken cancellationToken)
	{
		iotEdgeService.SetMethodHandlerAsync("Start", HandleStartOperation, new object());
		iotEdgeService.SetMethodHandlerAsync("Stop", HandleStopOperation, new object());
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask; // No specific stop logic needed for this example
	}

	private async Task<MethodResponse> HandleStartOperation(MethodRequest request, object userContext)
	{
		Settings.IsRunning = true; // Set the system to running state
		return new MethodResponse(200); // Return success response
	}

	private async Task<MethodResponse> HandleStopOperation(MethodRequest request, object userContext)
	{
		Settings.IsRunning = false; // Set the system to not running state
		return new MethodResponse(200); // Return success response
	}
}
