using Cantarus.Modules.PolyDeploy.Components.Logging;
using System;
using System.Linq;
using System.Net.Http;

namespace Cantarus.Modules.PolyDeploy.Components.WebAPI
{
    internal static class HttpRequestMessageExtensions
    {
        public static string GetApiKey(this HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var message = request.Headers.ToString() + " <br /> <br /> " + request.RequestUri;
            EventLogManager.Log("Get ApiKey Headers: ", EventLogSeverity.Info, message, null);
            // Is there an api key header present?
            if (request.Headers.Contains("x-api-key"))
            {
                EventLogManager.Log("Inside Contains x-api-key", EventLogSeverity.Info, request.Headers.GetValues("x-api-key").FirstOrDefault().ToString(), null);
                // Get the api key from the header.
                return request.Headers.GetValues("x-api-key").FirstOrDefault();
            }

            return null;
        }
    }
}
