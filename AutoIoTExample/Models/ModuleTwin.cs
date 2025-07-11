using AutoIoTEdge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoIoTExample.Models;
public class ModuleTwin : ModuleTwinBase
{
	public static string OperationMode { get; set; } = "Normal"; // Default operation mode
}
