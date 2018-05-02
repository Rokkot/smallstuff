using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Service;
using System.Reflection;

namespace ServiceTest
{
	class Program
	{
		static void Main(string[] args)
		{
			SKMain.Main_Service_Console<ServiceImpl>(Assembly.GetExecutingAssembly().GetName().Name, true);
		}
	}
}
