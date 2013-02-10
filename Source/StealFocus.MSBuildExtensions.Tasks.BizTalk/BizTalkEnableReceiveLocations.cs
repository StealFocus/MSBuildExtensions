// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkEnableReceiveLocations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkEnableReceiveLocations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkEnableReceiveLocations : BizTalkApplicationTask
    {
        [Required]
        public ITaskItem[] ReceiveLocationNames
        {
            get;
            set;
        }

        public override bool Execute()
        {
            BizTalkApplication bizTalkApplication = new BizTalkApplication(ManagementDatabaseConnectionString, ApplicationName);
            foreach (ITaskItem recieveLocationName in this.ReceiveLocationNames)
            {
                Log.LogMessage("Enabling Receive Location '{0}' for BizTalk application '{1}'.", recieveLocationName.ItemSpec, this.ApplicationName);
                bizTalkApplication.EnableReceiveLocation(recieveLocationName.ItemSpec);
            }

            return true;
        }
    }
}
