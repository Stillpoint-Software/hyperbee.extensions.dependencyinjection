using Lamar;
using Microsoft.Extensions.Configuration;

namespace Hyperbee.Extensions.Lamar;

public static class ServiceRegistryExtensions
{
    public static void IncludeStartupRegistry<T>( this ServiceRegistry registry, IConfiguration configuration )
        where T : class, IStartupRegistry
    {
        var type = typeof(T);

        if ( RegistryHelper.IsStartupRegistry( type ) )
            RegistryHelper.IncludeStartupRegistry( registry, type, configuration );
    }
}