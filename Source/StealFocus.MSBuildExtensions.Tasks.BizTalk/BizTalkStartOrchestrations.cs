// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartOrchestrations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartOrchestrations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkStartOrchestrations : BizTalkApplicationTask
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
                Log.LogMessage("Starting Orchestration '{0}' for BizTalk application '{1}'.", orchestrationName.ItemSpec, this.ApplicationName);
                bizTalkApplication.StartOrchestration(orchestrationName.ItemSpec);
            }

            return true;
        }
    }
}