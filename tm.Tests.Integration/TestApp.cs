using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace tm.Tests.Integration
{
    internal sealed class TestApp : WebApplicationFactory<Program>
    {
        public HttpClient Client { get; private set; }

        public TestApp(Action<IServiceCollection> services)
        {
            Client = WithWebHostBuilder(builder => 
            {
                if(services != null)
                {
                    builder.ConfigureServices(services);
                }
                builder.UseEnvironment("test");
            }).CreateClient();
        }

    }
}
