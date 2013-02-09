namespace StealFocus.MSBuildExtensions.Tasks
{
    using System.Globalization;

    using Microsoft.Build.Utilities;

    public abstract class FrameworkVersionDependentTask : Task
    {
        public string FrameworkVersion { get; set; }

        /// <summary>
        /// Get the <see cref="TargetDotNetFrameworkVersion" /> from the <see cref="FrameworkVersion"/> property.
        /// </summary>
        /// <returns>A <see cref="TargetDotNetFrameworkVersion" />.</returns>
        protected TargetDotNetFrameworkVersion GetTargetDotNetFrameworkVersion()
        {
            if (this.FrameworkVersion == FrameworkVersions.Version20)
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

            if (this.FrameworkVersion == FrameworkVersions.Version40)
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

        /// <summary>
        /// Holds a set of valid .NET Framework versions.
        /// </summary>
        protected static class FrameworkVersions
        {
            /// <summary>
            /// Version 2.0.
            /// </summary>
            public const string Version20 = "2.0";

            /// <summary>
            /// Version 3.0.
            /// </summary>
            public const string Version30 = "3.0";

            /// <summary>
            /// Version 3.5.
            /// </summary>
            public const string Version35 = "3.5";

            /// <summary>
            /// Version 3.5.
            /// </summary>
            public const string Version40 = "4.0";
        }
    }
}
