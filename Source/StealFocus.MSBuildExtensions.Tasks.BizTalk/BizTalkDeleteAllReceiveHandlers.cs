// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDeleteAllReceiveHandlers.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDeleteAllReceiveHandlers type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkDeleteAllReceiveHandlers : BizTalkHostTask
    {
        public override bool Execute()
        {
            string[] receiveHandlers = Host.GetReceiveHandlers(HostName);
            foreach (string receiveHandler in receiveHandlers)
            {
                Log.LogMessage("Deleting Receive Handler for Host '{0}' and Adapter '{1}'.", this.HostName, receiveHandler);
                ReceiveHandler.Delete(receiveHandler, this.HostName);
            }

            return true;
        }
    }
}