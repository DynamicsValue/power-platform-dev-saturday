//Based on koolin's repo: https://github.com/CdsWeb-app/CdsWeb/blob/master/src/CdsWeb/Extensions/CdsServiceClientExtensions.cs

using System;
using CdsWeb.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Powerplatform.Cds.Client;

namespace web.Extensions
{
    public class CdsServiceClientWrapper
    {
        public readonly CdsServiceClient CdsServiceClient;

        public CdsServiceClientWrapper(string connectionString, ILogger<CdsServiceClientWrapper> logger, string traceLevel = "Off")
        {
            TraceControlSettings.TraceLevel =
                (System.Diagnostics.SourceLevels)Enum.Parse(
                    typeof(System.Diagnostics.SourceLevels), traceLevel);

            TraceControlSettings.AddTraceListener(
                new LoggerTraceListener(
                    "Microsoft.PowerPlatform.Cds.Client", logger
                    )
                );

            CdsServiceClient = new CdsServiceClient(connectionString ?? throw new ArgumentNullException(nameof(connectionString)));
        }
    }
}