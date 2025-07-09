using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text;

namespace AutoIoTExample.Services;
public class SetupService(IIotEdgeService<ModuleTwin> iotEdgeService) : IHostedService
{
	public Task StartAsync(CancellationToken cancellationToken)
	{
		iotEdgeService.SetMethodHandlerAsync("Stop", HandleStopCommand, iotEdgeService);
		iotEdgeService.SetMethodHandlerAsync("Start", HandleStartCommand, iotEdgeService);
		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask; // No specific cleanup needed for this service
	}

	private async Task<MethodResponse> HandleStopCommand(MethodRequest request, object userContext)
	{
		Settings.IsTurnedOn = false; // Set the module to "off" state
		return new MethodResponse(Encoding.UTF8.GetBytes("Module is now stopped."), 200);
	}

	private async Task<MethodResponse> HandleStartCommand(MethodRequest request, object userContext)
	{
		Settings.IsTurnedOn = true; // Set the module to "on" state
		return new MethodResponse(Encoding.UTF8.GetBytes("Module is now started."), 200);
	}
}
