// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkStartHost.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkStartHost type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkStartHost : BizTalkHostTask
    {
        public override bool Execute()
        {
            if (Host.Exists(this.HostName))
            {
                Log.LogMessage("Starting BizTalk Host '{0}'.", this.HostName);
                Host.Start(this.HostName);
            }
            else
            {
                Log.LogMessage("BizTalk Host '{0}' does not exist, skipping start action.", this.HostName);
            }

            return true;
        }
    }
}