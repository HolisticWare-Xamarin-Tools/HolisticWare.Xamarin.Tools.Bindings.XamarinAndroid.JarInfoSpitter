using System;

namespace HolisticWare.XamarinAndroid.Bindings.jarInfoSpitter.DLL
{
	public class JavaClass
	{
		public JavaClass ()
		{
			this.Application 	= "javap";
			this.Arguments 		= "-classpath {JARNAME} {FULLY_QUALIFIED_CLASSNAME}";
		
			this.ClassNameStringFromJarTFChanged += JavaClass_ClassNameStringFromJarTFChanged;

			return;
		}

		public string JarName
		{
			get;
			set;
		}

		public string Arguments
		{
			get;
			set;
		}

		public string Application
		{
			get;
			set;
		}

		public string JavaPClasspathResult
		{
			get;
			set;
		}

		//-------------------------------------------------------------------------
		# region Property string ClassNameStringFromJarTF w Event post (ClassNameStringFromJarTFChanged)
		/// <summary>
		/// ClassNameStringFromJarTF
		/// </summary>
		public
		  string
		  ClassNameStringFromJarTF
		{
			get
			{
				return classname_for_javap_classpath;
			} // ClassNameStringFromJarTF.get
			set
			{
				//if (classname_for_javap_classpath != value)		// do not write if equivalent/equal/same
				{
					// for multi threading apps uncomment lines beginnig with //MT:
					//MT: lock(classname_for_javap_classpath) // MultiThread safe				
					{
						classname_for_javap_classpath = value;
						if (null != ClassNameStringFromJarTFChanged)
						{
							ClassNameStringFromJarTFChanged(this, new EventArgs());
						}
					}
				}
			} // ClassNameStringFromJarTF.set
		} // ClassNameStringFromJarTF

		/// <summary>
		/// private member field for holding ClassNameStringFromJarTF data
		/// </summary>
		private
			string
			classname_for_javap_classpath
			;

		///<summary>
		/// Event for wiring BusinessLogic object changes and presentation
		/// layer notifications.
		/// ClassNameStringFromJarTFChanged (<propertyname>Changed) is intercepted by Windows Forms
		/// 1.x and 2.0 event dispatcher 
		/// and for some CLR types by WPF event dispatcher 
		/// usually INotifyPropertyChanged and PropertyChanged event
		///</summary>
		public
			event
			EventHandler
			ClassNameStringFromJarTFChanged
			;
		# endregion Property string ClassNameStringFromJarTF w Event post (ClassNameStringFromJarTFChanged)
		//-------------------------------------------------------------------------

	
		public string ClassNameForJavaPClasspath
		{
			get;
			set;
		}

		void JavaClass_ClassNameStringFromJarTFChanged (object sender, EventArgs e)
		{
			if ("META-INF/MANIFEST.MF" == this.ClassNameStringFromJarTF)
			{
				return;
			}
			else
			{
				string jartf_class = this.ClassNameStringFromJarTF;

				this.ClassNameForJavaPClasspath = 
					this.ClassNameStringFromJarTF
						.Replace("/",".")
						.Replace(".class","")
						;

				string javap_classpath = this.JavapClasspath();

				this.JavaPClasspathResult = javap_classpath;
			}

			return;
		}

		public string JavapClasspath()
		{
			string args =
				this.Arguments
							.Replace("{FULLY_QUALIFIED_CLASSNAME}", this.ClassNameForJavaPClasspath)
							.Replace("{JARNAME}", this.JarName)
							;

			//=========================================================================
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.StartInfo.FileName = this.Application;
			process.StartInfo.Arguments = args;

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

			System.Text.StringBuilder javap_classpath = new System.Text.StringBuilder();

			while (!process.StandardOutput.EndOfStream)
			{
				string line = process.StandardOutput.ReadLine();

				javap_classpath.Append(line);
				javap_classpath.Append(Environment.NewLine);
			}

			return javap_classpath.ToString();
		}
	}
}

