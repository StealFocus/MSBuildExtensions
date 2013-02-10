// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDisableAllReceiveLocations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDisableAllReceiveLocations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDisableAllReceiveLocations : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Disabling all Receive Locations for BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.DisableAllReceiveLocations();
            return true;
        }
    }
}
