using AutoIoTEdge.Services;
using AutoIoTExample.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;

namespace AutoIoTExample.Services;
public class SetupService
{
	public SetupService(IIotEdgeService<ModuleTwin> iotEdgeService)
	{
		iotEdgeService.SetMethodHandlerAsync("Stop", HandleStopCommand, iotEdgeService);
		iotEdgeService.SetMethodHandlerAsync("Start", HandleStartCommand, iotEdgeService);
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
