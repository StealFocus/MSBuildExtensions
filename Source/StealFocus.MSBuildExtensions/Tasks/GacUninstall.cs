// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="GacUninstall.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the GacUninstall type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    using StealFocus.BclExtensions;

    public class GacUninstall : FrameworkVersionDependentTask
    {
        private const string GacUtilDotExeName = "gacutil.exe";

        private const string Wildcard = "*";

        private const int MinimumAssemblyNameLength = 6;

        private static readonly string[] ReservedAssemblyNames = new[] { "Accessibility", "ADODB", "Audit", "AspNet", "blb", "cas", "cfs", "com", "Cpp", "csc", "custom", "dfs", "dte", "env", "event", "ext", "FSharp", "hpcasl", "IE", "Interop", "MFC", "Microsoft", "MMC", "MQ", "MS", "nap", "nfs", "office", "policy", "Presentation", "Reach", "rmConfig", "RSSSharePoint", "Sdm", "Security", "Sentinel", "Server", "Setup", "SMDiagnostic", "SMSvcHost", "soapsudcode", "srmlib", "SrpUx", "stdole", "StorageMgmt", "sysglobl", "System", "Task", "UIAutomation", "VB", "VSLang", "VSTA", "VSTO", "VsWebSite", "WcfSvcHost", "WebDev", "Windows", "Wsat" };

        [Required]
        public string AssemblyName
        {
            get;
            set;
        }

        [Required]
        public string PublicKeyToken
        {
            get;
            set;
        }

        [Required]
        public string Version
        {
            get;
            set;
        }

        [Required]
        public string Locale
        {
            get;
            set;
        }

        public override bool Execute()
        {
            if (this.AssemblyName == Wildcard)
            {
                Log.LogError("Please do not supply a wildcard ({0}) alone as the Assembly name, this would removed all Assemblies from the GAC.", Wildcard);
                return false;
            }

            if (this.AssemblyName.Length <= MinimumAssemblyNameLength)
            {
                Log.LogError("Please supply an Assembly name longer than {0} characters to reduce the risk of removing Assemblies un-intentionally.", MinimumAssemblyNameLength);
                return false;
            }

            GlobalAssemblyCacheItem[] gacAssemblies = GlobalAssemblyCache.GetAssemblyList(GlobalAssemblyCacheCategoryTypes.Gac);
            ArrayList assembliesToBeRemovedFromGacList = new ArrayList();
            foreach (GlobalAssemblyCacheItem gacAssembly in gacAssemblies)
            {
                if (this.AssemblyShouldBeRemoved(gacAssembly))
                {
                    foreach (string reservedAssemblyName in ReservedAssemblyNames)
                    {
                        if (gacAssembly.Name.StartsWith(reservedAssemblyName, StringComparison.OrdinalIgnoreCase))
                        {
                            Log.LogError("The Assembly name '{0}' is a system Assembly and should not be removed from the GAC.", this.AssemblyName);
                            return false;
                        }
                    }

                    string fullyQualifiedAssemblyName = GetFullyQualifiedAssemblyName(gacAssembly);
                    assembliesToBeRemovedFromGacList.Add(fullyQualifiedAssemblyName);
                }
            }

            if (assembliesToBeRemovedFromGacList.Count > 0)
            {
                Log.LogMessage("Removing Assemblies from the GAC.");
                this.RemoveAssembliesFromGac((string[])assembliesToBeRemovedFromGacList.ToArray(typeof(string)));
            }
            else
            {
                Log.LogMessage("No Assemblies were found in the GAC matching the criteria.");
            }

            return true;
        }

        private static bool AssemblyIdComponentMatches(string assemblyIdComponent, string specifiedAssemblyIdComponent)
        {
            bool match = false;
            if (specifiedAssemblyIdComponent.EndsWith(Wildcard, StringComparison.OrdinalIgnoreCase))
            {
                string specifiedAssemblyIdComponentMinusWildcard = specifiedAssemblyIdComponent.Substring(0, specifiedAssemblyIdComponent.Length - 1);
                if (assemblyIdComponent.StartsWith(specifiedAssemblyIdComponentMinusWildcard, StringComparison.OrdinalIgnoreCase))
                {
                    match = true;
                }
            }
            else
            {
                if (assemblyIdComponent == specifiedAssemblyIdComponent)
                {
                    match = true;
                }
            }

            return match;
        }

        private static string GetFullyQualifiedAssemblyName(GlobalAssemblyCacheItem globalAssemblyCacheItem)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0},Version={1},Culture={2},PublicKeyToken={3}", globalAssemblyCacheItem.Name, globalAssemblyCacheItem.Version, globalAssemblyCacheItem.Locale, globalAssemblyCacheItem.PublicKeyToken);
        }

        private bool AssemblyShouldBeRemoved(GlobalAssemblyCacheItem globalAssemblyCacheItem)
        {
            bool shouldBeRemoved = AssemblyIdComponentMatches(globalAssemblyCacheItem.Name, this.AssemblyName) &&
                                   AssemblyIdComponentMatches(globalAssemblyCacheItem.Version, this.Version) &&
                                   AssemblyIdComponentMatches(globalAssemblyCacheItem.Locale, this.Locale) &&
                                   AssemblyIdComponentMatches(globalAssemblyCacheItem.PublicKeyToken, this.PublicKeyToken);
            return shouldBeRemoved;
        }

        private void RemoveAssembliesFromGac(IEnumerable<string> assembliesToBeRemovedFromGac)
        {
            foreach (string assemblyToBeRemovedFromGac in assembliesToBeRemovedFromGac)
            {
                // /u myDll,Version=1.1.0.0,Culture=en,PublicKeyToken=874e23ab874e23ab
                Log.LogMessage(MessageImportance.High, "Removing Assembly '{0}' from the GAC.", assemblyToBeRemovedFromGac);
                string gacUtilArgs = string.Format(CultureInfo.CurrentCulture, "/u {0}", assemblyToBeRemovedFromGac);
                this.ExecuteGacUtilDotExe(gacUtilArgs);
            }
        }

        private void ExecuteGacUtilDotExe(string gacUtilDotExePathArguments)
        {
            string gacUtilDotExePath = ToolLocationHelper.GetPathToDotNetFrameworkSdkFile(GacUtilDotExeName, GetTargetDotNetFrameworkVersion());
            Log.LogMessage(gacUtilDotExePath + " " + gacUtilDotExePathArguments);
            ProcessStartInfo processStartInfo = new ProcessStartInfo(gacUtilDotExePath, gacUtilDotExePathArguments);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);
            string standardOutput = process.StandardOutput.ReadToEnd();
            string standardError = process.StandardError.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(standardOutput);
            Log.LogMessage(standardOutput);
            if (process.ExitCode != 0)
            {
                Console.WriteLine(standardError);
                Log.LogError(standardError);
            }
        }
    }
}