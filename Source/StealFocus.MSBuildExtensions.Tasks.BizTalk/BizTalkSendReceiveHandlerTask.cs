// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkSendReceiveHandlerTask.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkSendReceiveHandlerTask type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public abstract class BizTalkSendReceiveHandlerTask : Task
    {
        [Required]
        public string HostName
        {
            get;
            set;
        }

        [Required]
        public string AdapterName
        {
            get;
            set;
        }
    }
}