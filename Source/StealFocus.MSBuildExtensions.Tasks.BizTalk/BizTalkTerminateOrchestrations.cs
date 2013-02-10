// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkTerminateOrchestrations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkTerminateOrchestrations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkTerminateOrchestrations : BizTalkApplicationTask
    {
        [Required]
        public ITaskItem[] OrchestrationNames
        {
            get;
            set;
        }

        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            foreach (ITaskItem orchestrationName in this.OrchestrationNames)
            {
                Log.LogMessage("Terminating Orchestration '{0}' for BizTalk application '{1}'.", orchestrationName.ItemSpec, this.ApplicationName);
                bizTalkApplication.TerminateOrchestration(orchestrationName.ItemSpec);
            }

            return true;
        }
    }
}