// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDeleteHost.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDeleteHost type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDeleteHost : BizTalkHostTask
    {
        public override bool Execute()
        {
            if (Host.Exists(this.HostName))
            {
                Log.LogMessage("Deleting BizTalk Host '{0}'.", this.HostName);
                Host.Delete(this.HostName);
            }
            else
            {
                Log.LogMessage("BizTalk Host '{0}' does not exist, skipping delete action.", this.HostName);
            }

            return true;
        }
    }
}