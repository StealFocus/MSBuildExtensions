// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCleanHostQueue.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCleanHostQueue type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkCleanHostQueue : BizTalkHostTask
    {
        public override bool Execute()
        {
            Log.LogMessage("Executing task: {0}", GetType().FullName);
            Log.LogMessage("Cleaning Queue for BizTalk Host '{0}'.", this.HostName);
            Host.CleanQueue(this.HostName);
            Log.LogMessage("Finished Executing task: {0}", GetType().FullName);
            return true;
        }
    }
}