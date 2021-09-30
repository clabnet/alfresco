using FluentAssertions;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace it.conai.alfresco.wrapper
{
    public class ApiClient
    {
        private const string BaseUrl = "https://www.boredapi.com/api/activity";

        public void testGET()
        {
            var client = new RestClient();

            var request = new RestRequest(BaseUrl);

            var response = client.Execute(request);

            Debug.WriteLine(response.Content);

            Debug.WriteLine(HttpStatusCode.OK.ToString(), response.StatusCode);
        }

        public void basicAuthenticator()
        {
            string _username;
            string _password;

            HttpBasicAuthenticator _authenticator;

            _username = "username";
            _password = "password";

            _authenticator = new HttpBasicAuthenticator(_username, _password);

            var client = new RestClient();
            var request = new RestRequest();

            request.AddParameter(new Parameter("NotMatching", null, default));

            var expectedToken =
                $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_username}:{_password}"))}";

            // Act
            _authenticator.Authenticate(client, request);

            // Assert
            request.Parameters.Single(x => x.Name == "Authorization").Value.Should().Be(expectedToken);
        }
    }
}
