using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoIoTExample.Models;
public class Settings
{
	public static bool IsTurnedOn { get; set; } = true; // Default value is true, meaning the module is turned on by default.
}
