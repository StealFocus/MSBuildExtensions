// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkHostExists.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkHostExists type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkHostExists : BizTalkHostTask
    {
        [Output]
        public bool Exists
        {
            get;
            set;
        }

        public override bool Execute()
        {
            this.Exists = Host.Exists(this.HostName);
            return true;
        }
    }
}