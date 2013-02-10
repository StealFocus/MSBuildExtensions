// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkAdapterTask.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkAdapterTask type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public abstract class BizTalkAdapterTask : Task
    {
        [Required]
        public string AdapterName
        {
            get;
            set;
        }
    }
}
