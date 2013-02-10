// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="BizTalkApplicationTask.cs" company="StealFocus">
//   Copyright StealFocus. All rights reserved.
// </copyright>
// <summary>
//   Defines the BizTalkApplicationTask type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace StealFocus.MSBuildExtensions.Tasks.BizTalk
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public abstract class BizTalkApplicationTask : Task
    {
        [Required]
        public string ManagementDatabaseConnectionString
        {
            get;
            set;
        }

        [Required]
        public string ApplicationName
        {
            get;
            set;
        }

        public abstract override bool Execute();
    }
}