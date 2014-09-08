using System;
using System.Collections.Generic;

namespace HolisticWare.XamarinAndroid.Bindings.jarInfoSpitter.DLL
{
	public partial class JarInfo
	{
		public string Application
		{
			get;
			set;
		}

		public string Arguments
		{
			get;
			set;
		}

		public string JarName
		{
			get;
			set;
		}

		public JarInfo ()
		{
		}

		public JarInfo (string jarname)
		{
			this.JarName = jarname;

			return;
		}

		public List<JavaClass> JarTF ()
		{
			List<JavaClass> jar_tf = new List<JavaClass>();
			//=========================================================================
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.FileName = this.Application;
			process.StartInfo.Arguments = this.Arguments;

			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.UserName = "";
			//process.StartInfo.Password = "";
			process.StartInfo.LoadUserProfile = false;
			process.StartInfo.UseShellExecute = true;

			//.........................................................
			// output redirection
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			//.........................................................


			process.Start();
			//=========================================================================


			while (!process.StandardOutput.EndOfStream) 
			{
				string line = process.StandardOutput.ReadLine();

				JavaClass jc =  new JavaClass()
				{
					ClassNameStringFromJarTF = line
				};
				jar_tf.Add(jc);
			}

			return jar_tf;
		}
	}
}

