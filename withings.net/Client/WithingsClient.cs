using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using withings.net.Models;
using withings.net.Authentication;
using System.Collections.Generic;
using withings.net.Models.Sleep;
using withings.net.Models.Common;
using withings.net.Models.Measure;
using withings.net.Models.Heart;
using withings.net.Models.User;

namespace withings.net.Client
{
    public partial class WithingsClient : RestClient
    {
        private readonly IAuthentication _authenticator;
        private readonly WithingsCredentials _credentials;
        private AuthorizationResponse _authorization_response;

        private WithingsClient(IAuthentication authenticator, WithingsCredentials credentials)
        {
            if (authenticator == null)
                throw new ArgumentNullException(nameof(authenticator));

            _authenticator = authenticator;
            _credentials = credentials;
            this.BaseUrl = new Uri(ApiConstants.BaseApiUrl);
            this.AddDefaultHeader("Content-Type", "application/x-www-form-urlencoded");
            this.AddDefaultHeader("Accept", "application/json");
        }

        public static async Task<WithingsClient> CreateAsync(IAuthentication authenticator, WithingsCredentials credentials)
        {
            var client = new WithingsClient(authenticator, credentials);
            await client.InitializeAsync();

            return client;
        }

        private async Task InitializeAsync()
        {
            await AuthorizeAsync();
            await ExchangeToken();
        }

        #region Token Authentication Methods
        private async Task<AuthorizationResponse> AuthorizeAsync()
        {
            try
            {
                return _authorization_response = new AuthorizationResponse()
                {
                    AccessToken = await _authenticator.GetGetAuthorizationCode()
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<AuthorizationResponse> ExchangeToken()
        {
            try
            {
                var client = new RestClient(ApiConstants.AccessTokenUrl);
                RestRequest request = new RestRequest() { Method = Method.POST };

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Accept", "application/json");

                request.AddParameter("grant_type", "authorization_code");
                request.AddParameter("client_id", _credentials.ClientId);
                request.AddParameter("client_secret", _credentials.ClientSecret);
                request.AddParameter("code", _authorization_response.AccessToken);
                request.AddParameter("redirect_uri", _credentials.RedirectUrl);

                var resp = await client.ExecuteAsync(request);

                return _authorization_response = JsonConvert.DeserializeObject<AuthorizationResponse>(resp.Content);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<AuthorizationResponse> RefreshToken()
        {
            try
            {
                var client = new RestClient(ApiConstants.RefreshTokenUrl);
                RestRequest request = new RestRequest() { Method = Method.POST };

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Accept", "application/json");

                request.AddParameter("grant_type", "refresh_token");
                request.AddParameter("client_id", _credentials.ClientId);
                request.AddParameter("client_secret", _credentials.ClientSecret);
                request.AddParameter("refresh_token", _authorization_response.RefreshToken);

                var resp = await client.ExecuteAsync(request);

                return _authorization_response = JsonConvert.DeserializeObject<AuthorizationResponse>(resp.Content);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region User Endpoints

        public async Task<DeviceResponse> GetDevice()
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.User_GetDeviceEndPoint}
                }.ToNullableParamaters();

                return await ExecuteGetAsync<DeviceResponse>(ApiConstants.User_GetDeviceEndPoint, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion


        #region Measure Endpoints

        public async Task<MeasureResponse> GetMeasure(MeasureType measureType, MeasureCategory measureCategory, long? startDate = null, long? endDate = null, int? offset = null, long? lastUpdate = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Measure_GetMeasureEndPoint },
                    { "meastype", ((int)measureType).ToString() },
                    { "category", ((int)measureCategory).ToString() },
                    { "startdate", startDate },
                    { "enddate", endDate },
                    { "offset", offset},
                    { "lastupdate", lastUpdate },
                }.ToNullableParamaters();

                return await ExecuteGetAsync<MeasureResponse>(ApiConstants.Measure_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MeasureResponse> GetActivity(string startDate, string endDate, int? offset = null, string data_fields = null, long? lastUpdate = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Measure_GetActivityEndPoint },
                    { "startdateymd", startDate },
                    { "enddateymd", endDate},
                    { "offset", offset},
                    { "data_fields", data_fields },
                    { "lastupdate", lastUpdate },
                }.ToNullableParamaters();

                return await ExecuteGetAsync<MeasureResponse>(ApiConstants.Measure_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MeasureResponse> GetIntraActivity(string startDate, string endDate, string data_fields = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Measure_GetIntraDayActivityEndPoint },
                    { "startdateymd", startDate },
                    { "enddateymd", endDate},
                    { "data_fields", data_fields },
                }.ToNullableParamaters();

                return await ExecuteGetAsync<MeasureResponse>(ApiConstants.Measure_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MeasureResponse> GetWorkouts(string startDate, string endDate, long? lastUpdate = null, int? offset = null, string data_fields = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Measure_GetIntraDayActivityEndPoint },
                    { "startdateymd", startDate },
                    { "enddateymd", endDate},
                    { "lastupdate", lastUpdate},
                    { "offset", offset},
                    { "data_fields", data_fields },
                }.ToNullableParamaters();

                return await ExecuteGetAsync<MeasureResponse>(ApiConstants.Measure_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Heart Endpoints

        public async Task<HeartResponse> GetHeart(int signalId)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Heart_GetEndPoint},
                    { "signalid", signalId },
                }.ToNullableParamaters();

                return await ExecuteGetAsync<HeartResponse>(ApiConstants.Heart_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<HeartResponse> ListHeart(long? startDate = null, long? endDate = null, int? offset = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Heart_GetEndPoint},
                    { "startdate", endDate },
                    { "enddate", startDate},
                    { "offset", offset},
                }.ToNullableParamaters();

                return await ExecuteGetAsync<HeartResponse>(ApiConstants.Heart_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Sleep Endpoints
        public async Task<SleepResponse> GetSleep(long? startDate = null, long? endDate = null, string data_fields = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Sleep_GetEndPoint},
                    { "startdate", endDate },
                    { "enddate", startDate},
                    { "data_fields", data_fields},
                }.ToNullableParamaters();

                return await ExecuteGetAsync<SleepResponse>(ApiConstants.Sleep_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SleepResponse> GetSleep(string startdateymd = null, string enddateymd = null, string data_fields = null, long? lastupdate = null)
        {
            try
            {
                var paramaters = new Dictionary<string, object>
                {
                    { "action", ApiConstants.Sleep_GetEndPoint},
                    { "startdateymd ", startdateymd },
                    { "enddateymd", enddateymd},
                    { "data_fields", data_fields},
                    { "lastupdate", lastupdate},
                }.ToNullableParamaters();

                return await ExecuteGetAsync<SleepResponse>(ApiConstants.Sleep_PathSegment, paramaters);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Notify Endpoints

        #endregion

    }
}
