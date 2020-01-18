using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using withings.net.Authentication;
using withings.net.Client;

namespace withings.net.wpf.Authentication
{
    class BrowserAuthenticator : IAuthentication
    {
        public Task<string> GetGetAuthorizationCode()
        {
            throw new NotImplementedException();
        }
    }
}
