using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StaticFilesWebServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseStaticFiles();
            var baseUrl = configuration.GetValue<string>("Kestrel:Endpoints:Http:Url");
            var autoStartBrowserPath = configuration.GetValue<string>("AutoStartBrowserPath");
            if (!string.IsNullOrWhiteSpace(autoStartBrowserPath))
            {
                System.Diagnostics.Process.Start("cmd", $"/C start {baseUrl}{autoStartBrowserPath}");
                System.Console.WriteLine($"首頁路徑: {baseUrl}{autoStartBrowserPath}");
            }
        }
    }
}
