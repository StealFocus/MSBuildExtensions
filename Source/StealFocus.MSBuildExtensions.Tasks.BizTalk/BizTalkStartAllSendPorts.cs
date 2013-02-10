// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartAllSendPorts.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartAllSendPorts type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStartAllSendPorts : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Starting all Send Ports for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.StartAllSendPorts();
            return true;
        }
    }
}