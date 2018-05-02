using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileLockInfo
{
	class Program
	{
		static void Main (string[] args)
		{
			try
			{
				if (args == null || args.Length != 2)
				{
					Console.WriteLine ("Usage: FileLockInfo.exe <path to SysInternals tool handle.exe> <path to locked file>");
					return;
				}

				if (args[0] == "/?" || args[0] == "-h")
				{
					Console.WriteLine ("Usage: FileLockInfo.exe <path to SysInternals tool handle.exe> <path to locked file>");
					return;
				}

				if (File.Exists (args[0]) == false)
				{
					Console.WriteLine ("Usage: FileLockInfo.exe <path to SysInternals tool handle.exe> <path to locked file>");
					return;
				}

				if (File.Exists (args[1]) == false)
				{
					Console.WriteLine ("Usage: FileLockInfo.exe <path to SysInternals tool handle.exe> <path to locked file>");
					return;
				}

				List<Process> list = Win32Processes.GetProcessesLockingFile (args[1]);


				/*
				string HandleExefileName = args[0];
				string fileName = args[1]; //@"c:\aaa.doc";//Path to locked file

				Process tool = new Process ();
				tool.StartInfo.FileName = HandleExefileName;
				tool.StartInfo.Arguments = string.Format("-p {0}", fileName);
				tool.StartInfo.UseShellExecute = false;
				tool.StartInfo.RedirectStandardOutput = true;
				tool.Start ();
				tool.WaitForExit ();
				string outputTool = tool.StandardOutput.ReadToEnd ();
				Console.WriteLine (outputTool);
				string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
				foreach (Match match in Regex.Matches (outputTool, matchPattern))
				{
					Process.GetProcessById (int.Parse (match.Value)).Kill ();
				}
				*/
			}
			catch (Exception exp)
			{
				Console.WriteLine (exp.Message);
			}
			finally
			{
				Console.WriteLine ("\r\n Please press any key to exit.");
				Console.ReadKey ();
			}
		}
	}
}
