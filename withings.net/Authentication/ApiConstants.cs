namespace withings.net.Authentication
{
    public static class ApiConstants
    {
        public const string ApiVersion = @"v2";

        public const string AuthorizationCodeUrl = @"https://account.withings.com/oauth2_user/authorize2";
        public const string AccessTokenUrl = @"https://account.withings.com/oauth2/token";
        public const string RefreshTokenUrl = @"https://account.withings.com/oauth2/token";

        public const string BaseApiUrl = @"https://wbsapi.withings.net";

        #region User Endpoints
        public const string User_PathSegment = @"user";

        public const string User_GetDeviceEndPoint = @"getdevice";
        #endregion

        #region Measure Endpoints
        public const string Measure_PathSegment = @"measure";

        public const string Measure_GetMeasureEndPoint = @"getmeas";
        public const string Measure_GetActivityEndPoint = @"getactivity";
        public const string Measure_GetIntraDayActivityEndPoint = @"getintradayactivity";
        public const string Measure_GetWorkoutsEndPoint = @"getworkouts";
        #endregion

        #region Heart Endpoints
        public const string Heart_PathSegment = @"heart";

        public const string Heart_GetEndPoint = @"get";
        public const string Heart_ListEndPoint = @"list";
        #endregion

        #region Sleep Endpoints
        public const string Sleep_PathSegment = @"sleep";

        public const string Sleep_GetEndPoint = @"get";
        public const string Sleep_GetSummaryEndPoint = @"getsummary";
        #endregion

        #region Notify Endpoints
        public const string Notify_PathSegment = @"notify";

        public const string Notify_GetEndPoint = @"get";
        public const string Notify_ListEndPoint = @"list";
        public const string Notify_RevokeEndPoint = @"revoke";
        public const string Notify_SubscribeEndPoint = @"subscribe";
        public const string Notify_UpdateEndPoint = @"update";
        #endregion

    }
}