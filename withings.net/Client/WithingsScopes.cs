using System;

namespace withings.net.Client
{
    [Flags]
    public enum WithingsScopes
    {
        None = 0,
        UserInfo = 1,
        UserMetrics = 2,
        UserActivity = 4,
        UserSleepEvents = 8
    }

}
