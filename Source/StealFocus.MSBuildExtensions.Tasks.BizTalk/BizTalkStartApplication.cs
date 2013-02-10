// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartApplication.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartApplication type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStartApplication : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            Log.LogMessage("Starting BizTalk application '{0}'.", this.ApplicationName);
            bizTalkApplication.StartAll();
            return true;
        }
    }
}