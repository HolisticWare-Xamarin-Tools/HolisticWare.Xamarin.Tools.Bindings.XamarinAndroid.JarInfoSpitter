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
			JarInfo ji =  new JarInfo();
			ji.JarName = "accessory-v1.0.0.jar";


			List<JavaClass> result = ji.JarTF();

			return;
		}
	}
}
