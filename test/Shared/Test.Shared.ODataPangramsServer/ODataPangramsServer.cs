using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;

namespace Test.QueryFunctions.OData
{
    public static class ODataPangramsServer
    {
        public static TestServer CreateServer(string currentDirectory = null)
        {
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder();

            webHostBuilder.UseContentRoot(currentDirectory == null
                ? Directory.GetCurrentDirectory()
                : Directory.GetCurrentDirectory() + $"\\{currentDirectory}");


            webHostBuilder.UseStartup<TestStartup>();
            webHostBuilder.UseEnvironment("Test");

            return new TestServer(webHostBuilder);
        }
    }
}
