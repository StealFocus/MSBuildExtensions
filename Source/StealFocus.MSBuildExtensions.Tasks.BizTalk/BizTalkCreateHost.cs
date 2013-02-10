// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCreateHost.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCreateHost type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using System;

    using Microsoft.Build.Framework;

    public class BizTalkCreateHost : BizTalkHostTask
    {
        [Required]
        public string WindowsGroupName
        {
            get;
            set;
        }

        [Required]
        public bool Trusted
        {
            get;
            set;
        }

        [Required]
        public string HostType
        {
            get;
            set;
        }

        [Required]
        public bool HostTracking
        {
            get;
            set;
        }

        [Required]
        public bool IsDefault
        {
            get;
            set;
        }

        public override bool Execute()
        {
            StealFocus.BizTalkExtensions.HostType hostType;
            try
            {
                hostType = (StealFocus.BizTalkExtensions.HostType)Enum.Parse(typeof(StealFocus.BizTalkExtensions.HostType), this.HostType, false);
            }
            catch (FormatException)
            {
                Log.LogError("The provided Host Type of '{0}' could not be parsed as a valid Host Type. Possible values are '{}' and '{}'.", this.HostType, Microsoft.BizTalk.ExplorerOM.HostType.InProcess, Microsoft.BizTalk.ExplorerOM.HostType.Isolated);
                return false;
            }

            Log.LogMessage("Creating Host '{0}.", this.HostName);
            StealFocus.BizTalkExtensions.Host.Create(this.HostName, this.WindowsGroupName, this.Trusted, hostType, this.HostTracking, this.IsDefault);
            return true;
        }
    }
}