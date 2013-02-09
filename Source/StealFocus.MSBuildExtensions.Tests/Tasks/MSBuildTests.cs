// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MSBuildTests.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   MSBuildTests Class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StealFocus.MSBuildExtensions.Tests.Tasks
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StealFocus.BclExtensions;

    /// <summary>
    /// Base Class for testing MSBuild tasks.
    /// </summary>
    [TestClass]
    public abstract class MSBuildTests
    {
        protected const string MSBuildProjectFileName = "StealFocus.MSBuildExtensions.Tests.Tasks.msbuild";

        private static readonly string MicrosoftBuildPath = Environment.ExpandEnvironmentVariables(@"%systemdrive%\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe");

        [TestInitialize]
        public void Initialize()
        {
            Resource.GetFileAndWriteToPath("StealFocus.MSBuildExtensions.Tests", "StealFocus.MSBuildExtensions.Tests.Tasks.Resources.Tests.msbuild", MSBuildProjectFileName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(MSBuildProjectFileName);
        }

        protected static int RunMSBuild(string msbuildExeArguments)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(".");
            return RunMSBuild(msbuildExeArguments, directoryInfo.FullName);
        }

        protected static int RunMSBuild(string msbuildExeArguments, string workingDirectory)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(MicrosoftBuildPath, msbuildExeArguments);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = workingDirectory;
            Process process = Process.Start(processStartInfo);
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                Console.WriteLine(process.StandardError.ReadToEnd());
            }

            return process.ExitCode;
        }
    }
}