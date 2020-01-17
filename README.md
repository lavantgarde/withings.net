# Overview
A .NET SDK for the Withings API. The Core is in .NET Standard 2.0.

# How to use
```                                                   
            // Create your credentials
            var credentials = new WithingsCredentials(clientId: Environment.GetEnvironmentVariable("debug_client_id"),
                                                      clientSecret: Environment.GetEnvironmentVariable("debug_client_secret"),
                                                      scopes: WithingsScopes.UserActivity,
                                                      redirectUrl: Environment.GetEnvironmentVariable("debug_redirect_uri"),
                                                      state: "state");

            // Use an IAuthenticator, this implementation uses a browser authenticator for native desktop apps
            var browserAuthenticator = new BrowserAuthentication(credentials);
            
            // Asynchronously create the WithingsClient
            var withingsClient = await WithingsClient.CreateAsync(browserAuthenticator, credentials);                                   
```

