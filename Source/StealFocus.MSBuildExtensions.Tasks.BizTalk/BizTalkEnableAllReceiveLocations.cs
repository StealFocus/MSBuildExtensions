// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkEnableAllReceiveLocations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkEnableAllReceiveLocations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkEnableAllReceiveLocations : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Enabling all Receive Locations for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.EnableAllReceiveLocations();
            return true;
        }
    }
}