// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCreateHostInstance.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCreateHostInstance type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkCreateHostInstance : BizTalkHostTask
    {
        [Required]
        public string ServerName
        {
            get;
            set;
        }

        [Required]
        public string Password
        {
            get;
            set;
        }

        [Required]
        public string UserName
        {
            get;
            set;
        }

        public override bool Execute()
        {
            Log.LogMessage("Creating Host Instance for Server '{0}', Host '{1}' and Username '{2}'.", this.ServerName, this.HostName, this.UserName);
            Host.CreateInstance(this.ServerName, this.HostName, this.UserName, this.Password);
            return true;
        }
    }
}