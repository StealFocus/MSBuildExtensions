// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStopHost.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStopHost type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStopHost : BizTalkHostTask
    {
        public override bool Execute()
        {
            if (Host.Exists(this.HostName))
            {
                Log.LogMessage("Stopping BizTalk Host '{0}'.", this.HostName);
                Host.Stop(this.HostName);
            }
            else
            {
                Log.LogMessage("BizTalk Host '{0}' does not exist, skipping stop action.", this.HostName);
            }

            return true;
        }
    }
}