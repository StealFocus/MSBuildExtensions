// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartSendPorts.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartSendPorts type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkStartSendPorts : BizTalkApplicationTask
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
                Log.LogMessage("Starting Send Port '{0}' for BizTalk application '{1}'.", sendPortName.ItemSpec, this.ApplicationName);
                bizTalkApplication.StartSendPort(sendPortName.ItemSpec);
            }

            return true;
        }
    }
}