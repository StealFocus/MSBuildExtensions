// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStopAllSendPorts.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStopAllSendPorts type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStopAllSendPorts : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Stopping all Send Ports for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.StopAllSendPorts();
            return true;
        }
    }
}