// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDeleteAllSendHandlers.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDeleteAllSendHandlers type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDeleteAllSendHandlers : BizTalkHostTask
    {
        public override bool Execute()
        {
            string[] sendHandlers = Host.GetSendHandlers(HostName);
            foreach (string sendHandler in sendHandlers)
            {
                Log.LogMessage("Deleting Send Handler for Host '{0}' and Adapter '{1}'.", this.HostName, sendHandler);
                SendHandler.Delete(sendHandler, this.HostName);
            }

            return true;
        }
    }
}