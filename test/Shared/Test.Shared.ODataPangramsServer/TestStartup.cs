using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Mata007.QueryFunctions.OData;

namespace Test.QueryFunctions.OData
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOData(); // Microsoft.AspNetCore.OData 7.5.7
            //services.AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(100).AddModel("odata", GetEdmModel())); // Microsoft.AspNetCore.OData 8.0.0
            RegisterQueryFunctions.RegisterStringFuncs();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapODataRoute("odata", "odata", GetEdmModel()); // Microsoft.AspNetCore.OData 7.5.7
                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<PangramsDto>("Pangrams");
            return builder.GetEdmModel();
        }
    }
}
