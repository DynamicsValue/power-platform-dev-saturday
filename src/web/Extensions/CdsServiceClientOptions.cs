//Based on koolin's repo: https://github.com/CdsWeb-app/CdsWeb/blob/master/src/CdsWeb/Extensions/CdsServiceClientExtensions.cs

namespace web.Extensions
{
    public class CdsServiceClientOptions
    {
        /// <summary>
        /// <see cref="CdsServiceClient"/> constructors for connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Parameter to allow for transient OrganizationServiceContext service based on Clone
        /// of singleton CdsServiceClient.
        /// </summary>
        /// <see cref="OrganizationServiceContext"/>
        public bool IncludeOrganizationServiceContext { get; set; }

        /// <summary>
        /// Define a Trace Level for the CdsServiceClient
        /// Values are: All, Off, Critical, Error, Warning, Information, Verbose, ActivityTracing
        /// </summary>
        /// <see cref="System.Diagnostics.SourceLevels"/>
        public string TraceLevel { get; set; }
    }
}