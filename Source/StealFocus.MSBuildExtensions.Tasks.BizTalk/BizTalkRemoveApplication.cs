// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkRemoveApplication.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkRemoveApplication type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using System;

    using StealFocus.BizTalkExtensions;

    /// <summary>
    /// Remove a BizTalk application completely.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Example as follows:
    /// </para>
    /// <para>
    /// <![CDATA[
    ///   <UsingTask 
    ///     TaskName="StealFocus.MSBuildExtensions.Tasks.BizTalk.BizTalkRemoveApplication"
    ///     AssemblyFile="StealFocus.MSBuildExtensions.Tasks.BizTalk.dll" />
    /// ]]>
    /// <![CDATA[
    ///   <PropertyGroup>
    ///     <ManagementDatabaseConnectionString>server=.;database=BizTalkMgmtDb;integrated security=sspi;</ManagementDatabaseConnectionString>
    ///   </PropertyGroup>
    /// ]]>
    /// <![CDATA[
    ///   <Target Name="CreateAndRemove">
    ///     <BizTalkRemoveApplication
    ///       ManagementDatabaseConnectionString="$(ManagementDatabaseConnectionString)"
    ///       ApplicationName="MyTestApplication" />
    ///   </Target>
    /// ]]>
    /// </para>
    /// <para>
    /// Or use to delete multiple applications (<![CDATA[asterix]]> only works as a suffix):
    /// </para>
    /// <para>
    /// <![CDATA[
    ///   <UsingTask 
    ///     TaskName="StealFocus.MSBuildExtensions.Tasks.BizTalk.BizTalkRemoveApplication"
    ///     AssemblyFile="StealFocus.MSBuildExtensions.Tasks.BizTalk.dll" />
    /// ]]>
    /// <![CDATA[
    ///   <PropertyGroup>
    ///     <ManagementDatabaseConnectionString>server=.;database=BizTalkMgmtDb;integrated security=sspi;</ManagementDatabaseConnectionString>
    ///   </PropertyGroup>
    /// ]]>
    /// <![CDATA[
    ///   <Target Name="CreateAndRemove">
    ///     <BizTalkRemoveApplication
    ///       ManagementDatabaseConnectionString="$(ManagementDatabaseConnectionString)"
    ///       ApplicationName="MyTest*" />
    ///   </Target>    
    /// ]]>
    /// </para>
    /// <para>
    /// In the above example, all applications starting with "MyTest" will be removed. Please note the applications
    /// will be deleted as they are found in the BizTalk Catalogue, any inter-dependencies may cause errors when the 
    /// removal is attempted. Where inter-dependencies exist, please use the task multiple times to dictate the 
    /// removal order.
    /// </para>
    /// </remarks>
    public class BizTalkRemoveApplication : BizTalkApplicationTask
    {
        public override bool Execute()
        {
            BizTalkCatalogExplorer bizTalkCatalogExplorer = new BizTalkCatalogExplorer(ManagementDatabaseConnectionString);
            if (ApplicationName.EndsWith("*", StringComparison.OrdinalIgnoreCase))
            {
                string applicationNameToMatch = ApplicationName.Substring(0, ApplicationName.Length - 1);
                string[] applicationNames = bizTalkCatalogExplorer.GetApplicationNames();
                foreach (string applicationName in applicationNames)
                {
                    if (applicationName.StartsWith(applicationNameToMatch, StringComparison.OrdinalIgnoreCase))
                    {
                        Log.LogMessage("Removing BizTalk application '{0}'...", applicationName);
                        bizTalkCatalogExplorer.RemoveApplication(applicationName);
                        Log.LogMessage("...BizTalk application '{0}' successfully removed.", applicationName);
                    }
                }
            }
            else if (bizTalkCatalogExplorer.ApplicationExists(this.ApplicationName))
            {
                Log.LogMessage("Removing BizTalk application '{0}'...", this.ApplicationName);
                bizTalkCatalogExplorer.RemoveApplication(this.ApplicationName);
                Log.LogMessage("...BizTalk application '{0}' successfully removed.", this.ApplicationName);
            }
            else
            {
                Log.LogMessage("No matches were found for BizTalk application named '{0}', skipping removal.", this.ApplicationName);
            }

            return true;
        }
    }
}