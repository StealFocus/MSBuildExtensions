// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDeleteSendHandler.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDeleteSendHandler type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDeleteSendHandler : BizTalkSendReceiveHandlerTask
    {
        public override bool Execute()
        {
            if (SendHandler.Exists(this.AdapterName, this.HostName))
            {
                Log.LogMessage("Deleting Send Handler for Host '{0}' and Adapter '{1}'.", this.HostName, this.AdapterName);
                SendHandler.Delete(this.AdapterName, this.HostName);
            }
            else
            {
                Log.LogMessage("Send Handler for Host '{0}' and Adapter '{1}' was not found.", this.HostName, this.AdapterName);
            }

            return true;
        }
    }
}