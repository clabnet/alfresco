using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using it.conai.alfresco.wrapper;

namespace it.conai.alfresco.console
{
    class Program
    {
        /// <summary>
        /// Use REST client https://restsharp.dev/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ApiClient apiClient = new wrapper.ApiClient();

            apiClient.basicAuthenticator();

            apiClient.testGET();

        }
    }
}
