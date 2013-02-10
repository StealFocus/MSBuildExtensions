// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCreateSendHandler.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCreateSendHandler type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkCreateSendHandler : BizTalkSendReceiveHandlerTask
    {
        public bool IsDefault
        {
            get;
            set;
        }

        public override bool Execute()
        {
            if (SendHandler.Exists(this.AdapterName, this.HostName))
            {
                Log.LogMessage("Send Handler for Host '{0}' and Adapter '{1}' already exists, skipping create action.", this.HostName, this.AdapterName);
            }
            else
            {
                Log.LogMessage("Creating Send Handler for Host '{0}' and Adapter '{1}'.", this.HostName, this.AdapterName);
                SendHandler.Create(this.AdapterName, this.HostName, this.IsDefault);
            }

            return true;
        }
    }
}