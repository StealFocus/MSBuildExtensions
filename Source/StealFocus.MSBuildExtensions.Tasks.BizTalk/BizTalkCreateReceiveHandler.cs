// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCreateReceiveHandler.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCreateReceiveHandler type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkCreateReceiveHandler : BizTalkSendReceiveHandlerTask
    {
        public override bool Execute()
        {
            if (ReceiveHandler.Exists(this.AdapterName, this.HostName))
            {
                Log.LogMessage("Receive Handler for Host '{0}' and Adapter '{1}' already exists, skipping create action.", this.HostName, this.AdapterName);
            }
            else
            {
                Log.LogMessage("Creating Receive Handler for Host '{0}' and Adapter '{1}'.", this.HostName, this.AdapterName);
                ReceiveHandler.Create(this.AdapterName, this.HostName);
            }

            return true;
        }
    }
}