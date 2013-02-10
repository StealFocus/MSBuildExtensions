// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkCreateApplication.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkCreateApplication type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using StealFocus.BizTalkExtensions;

    public class BizTalkCreateApplication : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkCatalogExplorer bizTalkCatalogExplorer = new BizTalkCatalogExplorer(ManagementDatabaseConnectionString);
            if (bizTalkCatalogExplorer.ApplicationExists(this.ApplicationName))
            {
                Log.LogMessage("A BizTalk application with the name '{0}' already exists.", this.ApplicationName);
                return false;
            }

            Log.LogMessage("Creating a BizTalk application with the name '{0}'.", this.ApplicationName);
            bizTalkCatalogExplorer.CreateApplication(this.ApplicationName);
            return true;
        }
    }
}