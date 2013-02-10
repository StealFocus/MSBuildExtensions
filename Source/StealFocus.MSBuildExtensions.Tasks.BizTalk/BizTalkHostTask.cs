// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkHostTask.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkHostTask type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public abstract class BizTalkHostTask : Task
    {
        [Required]
        public string HostName
        {
            get;
            set;
        }
    }
}