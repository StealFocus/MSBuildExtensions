// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkTerminateAllOrchestrations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkTerminateAllOrchestrations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkTerminateAllOrchestrations : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Terminating all Orchestrations for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.TerminateAllOrchestrations();
            return true;
        }
    }
}