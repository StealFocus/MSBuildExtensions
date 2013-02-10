// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartAllOrchestrations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartAllOrchestrations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStartAllOrchestrations : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Starting all Orchestrations for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.StartAllOrchestrations();
            return true;
        }
    }
}