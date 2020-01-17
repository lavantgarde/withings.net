using System;
using System.Text;

namespace withings.net.Client
{
    public static class ModelExtensionMethods
    {

        public static string ConvertToString(this WithingsScopes scopes)
        {
            var sb = new StringBuilder();
            if (scopes.HasFlag(WithingsScopes.UserActivity))
                sb.Append("user.activity,");
            if (scopes.HasFlag(WithingsScopes.UserInfo))
                sb.Append("user.info,");
            if (scopes.HasFlag(WithingsScopes.UserMetrics))
                sb.Append("user.metrics,");
            if (scopes.HasFlag(WithingsScopes.UserSleepEvents))
                sb.Append("user.sleepevents");

            var str = sb.ToString();
            return Uri.EscapeDataString(str.Substring(0, str.LastIndexOf(',')));
        }

    }

}
