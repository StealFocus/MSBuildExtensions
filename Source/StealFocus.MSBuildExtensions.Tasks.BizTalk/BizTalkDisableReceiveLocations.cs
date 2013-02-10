// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkDisableReceiveLocations.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkDisableReceiveLocations type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;

    using StealFocus.BizTalkExtensions;

    public class BizTalkDisableReceiveLocations : BizTalkApplicationTask
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
                Log.LogMessage("Disabling Receive Location '{0}' for BizTalk application '{1}'.", recieveLocationName.ItemSpec, this.ApplicationName);
                bizTalkApplication.DisableReceiveLocation(recieveLocationName.ItemSpec);
            }

            return true;
        }
    }
}
