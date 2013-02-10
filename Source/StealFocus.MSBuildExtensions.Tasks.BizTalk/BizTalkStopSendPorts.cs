// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStopSendPorts.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStopSendPorts type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkStopSendPorts : BizTalkApplicationTask
    {
        [Required]
        public ITaskItem[] SendPortNames
        {
            get;
            set;
        }

        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            foreach (ITaskItem sendPortName in this.SendPortNames)
            {
                Log.LogMessage("Stopping Send Port '{0}' for BizTalk application '{1}'.", sendPortName.ItemSpec, this.ApplicationName);
                bizTalkApplication.StopSendPort(sendPortName.ItemSpec);
            }

            return true;
        }
    }
}