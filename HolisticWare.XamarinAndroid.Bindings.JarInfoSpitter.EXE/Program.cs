using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HolisticWare.XamarinAndroid.Bindings.jarInfoSpitter.DLL;

namespace HolisticWare.XamarinAndroid.Bindings.JarInfoSpitter.EXE
{
	class Program
	{
		static void Main(string[] args)
		{
			string application = "jar";
			string arguments = "tf {JARNAME}";

			arguments = arguments.Replace("{JARNAME}", "accessory-v1.0.0.jar");

			JarInfo ji =  new JarInfo();
			ji.Application = application;
			ji.Arguments = arguments;

			var result = ji.JarTF();
			
		}
	}
}
