using BrewUp.Rest.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BrewUp.Rest.Modules
{
    public sealed class StatusModule : IModule
    {
        public bool IsEnabled => true;
        public int Order => 0;

        public IServiceCollection RegisterModule(WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks();

            return builder.Services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            {
                ResponseWriter = HealthCheckHelper.WriteResponse
            });

            return endpoints;
        }
    }
}