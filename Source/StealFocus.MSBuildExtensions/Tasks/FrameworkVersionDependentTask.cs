namespace StealFocus.MSBuildExtensions.Tasks
{
    using System.Globalization;

    using Microsoft.Build.Utilities;

    public abstract class FrameworkVersionDependentTask : Task
    {
        public string FrameworkVersion { get; set; }

        protected TargetDotNetFrameworkVersion GetTargetDotNetFrameworkVersion()
        {
            if (this.FrameworkVersion == FrameworkVersions.Version20Simple || this.FrameworkVersion == FrameworkVersions.Version20Qualified)
            {
                return TargetDotNetFrameworkVersion.Version20;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version30)
            {
                return TargetDotNetFrameworkVersion.Version30;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version35)
            {
                return TargetDotNetFrameworkVersion.Version35;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version40Simple || this.FrameworkVersion == FrameworkVersions.Version40Qualified)
            {
                return TargetDotNetFrameworkVersion.Version40;
            }

            if (string.IsNullOrEmpty(this.FrameworkVersion))
            {
                return TargetDotNetFrameworkVersion.VersionLatest;
            }

            string exceptionMessage = string.Format(CultureInfo.CurrentCulture, "The .NET Framework version '{0}' was not supported.", this.FrameworkVersion);
            throw new MSBuildExtensionsException(exceptionMessage);
        }

        protected static class FrameworkVersions
        {
            public const string Version20Simple = "2.0";

            public const string Version20Qualified = "2.0.50727";

            public const string Version30 = "3.0";

            public const string Version35 = "3.5";

            public const string Version40Simple = "4.0";

            public const string Version40Qualified = "4.0.30319";
        }
    }
}
