namespace StealFocus.MSBuildExtensions.Tasks
{
    using System.Globalization;

    using Microsoft.Build.Utilities;

    public abstract class FrameworkVersionDependentTask : Task
    {
        public string FrameworkVersion { get; set; }

        protected TargetDotNetFrameworkVersion GetTargetDotNetFrameworkVersion()
        {
            if (this.FrameworkVersion == FrameworkVersions.Version20Simple ||
                this.FrameworkVersion == FrameworkVersions.Version20SimpleWithPrefix ||
                this.FrameworkVersion == FrameworkVersions.Version20Qualified || 
                this.FrameworkVersion == FrameworkVersions.Version20QualifiedWithPrefix)
            {
                return TargetDotNetFrameworkVersion.Version20;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version30 ||
                this.FrameworkVersion == FrameworkVersions.Version30WithPrefix)
            {
                return TargetDotNetFrameworkVersion.Version30;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version35 ||
                this.FrameworkVersion == FrameworkVersions.Version35WithPrefix)
            {
                return TargetDotNetFrameworkVersion.Version35;
            }

            if (this.FrameworkVersion == FrameworkVersions.Version40Simple ||
                this.FrameworkVersion == FrameworkVersions.Version40SimpleWithPrefix ||
                this.FrameworkVersion == FrameworkVersions.Version40Qualified || 
                this.FrameworkVersion == FrameworkVersions.Version40QualifiedWithPrefix)
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

            public const string Version20SimpleWithPrefix = "v2.0";

            public const string Version20Qualified = "2.0.50727";

            public const string Version20QualifiedWithPrefix = "v2.0.50727";

            public const string Version30 = "3.0";

            public const string Version30WithPrefix = "v3.0";

            public const string Version35 = "3.5";

            public const string Version35WithPrefix = "v3.5";

            public const string Version40Simple = "4.0";

            public const string Version40SimpleWithPrefix = "v4.0";

            public const string Version40Qualified = "4.0.30319";

            public const string Version40QualifiedWithPrefix = "v4.0.30319";
        }
    }
}
