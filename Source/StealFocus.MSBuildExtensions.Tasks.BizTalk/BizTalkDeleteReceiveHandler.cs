// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDeleteReceiveHandler.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDeleteReceiveHandler type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDeleteReceiveHandler : BizTalkSendReceiveHandlerTask
    {
        public override bool Execute()
        {
            if (ReceiveHandler.Exists(this.AdapterName, this.HostName))
            {
                Log.LogMessage("Deleting Receive Handler for Host '{0}' and Adapter '{1}'.", this.HostName, this.AdapterName);
                ReceiveHandler.Delete(this.AdapterName, this.HostName);
            }
            else
            {
                Log.LogMessage("Receive Handler for Host '{0}' and Adapter '{1}' was not found.", this.HostName, this.AdapterName);
            }

            return true;
        }
    }
}