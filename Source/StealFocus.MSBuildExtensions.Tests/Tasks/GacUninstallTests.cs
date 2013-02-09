// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GacUninstallTests.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   GacUninstallTests Class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StealFocus.MSBuildExtensions.Tests.Tasks
{
    using System.Globalization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GacUninstallTests : MSBuildTests
    {
        [TestMethod]
        public void IntegrationTest_That_GacUninstall_Is_A_Success()
        {
            const string TargetName = "GacUninstallSuccess";
            string arguments = string.Format(CultureInfo.CurrentCulture, "{0} /t:{1}", MSBuildProjectFileName, TargetName);
            int exitCode = RunMSBuild(arguments);
            Assert.IsTrue(exitCode == 0, "The MSBuild Task failed when it was not expected to.");
        }
    }
}
