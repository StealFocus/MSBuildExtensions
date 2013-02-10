// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStopApplication.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStopApplication type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStopApplication : BizTalkApplicationTask
    {
        public bool TerminateOrchestrations
        {
            get;
            set;
        }

        public override bool Execute()
        {
            BizTalkCatalogExplorer bizTalkCatalogExplorer = new BizTalkCatalogExplorer(ManagementDatabaseConnectionString);
            if (bizTalkCatalogExplorer.ApplicationExists(this.ApplicationName))
            {
                BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
                if (this.TerminateOrchestrations)
                {
                    Log.LogMessage("Disabling all Receive Locations for BizTalk application '{0}'.", this.ApplicationName);
                    bizTalkApplication.DisableAllReceiveLocations();
                    Log.LogMessage("Terminating all Orchestrations for BizTalk application '{0}'.", this.ApplicationName);
                    bizTalkApplication.TerminateAllOrchestrations();
                }

                Log.LogMessage("Bringing BizTalk application '{0}' to a complete stop.", this.ApplicationName);
                bizTalkApplication.StopAll();
            }
            else
            {
                Log.LogMessage("Skipping stopping of BizTalk application '{0}' as none exist matching that name.", this.ApplicationName);
            }

            return true;
        }
    }
}