using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MapaDaForca.Areas.Identity.IdentityHostingStartup))]
namespace MapaDaForca.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}