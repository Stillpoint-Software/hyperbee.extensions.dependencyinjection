using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hyperbee.Extensions.DependencyInjection;

public static class HostBuilderExtensions
{
    // Extension to support UseStartup<TStartup>() for Console hosts

    public static IHostBuilder UseStartup<TStartup>( this IHostBuilder hostBuilder )
        where TStartup : class
    {
        hostBuilder.ConfigureServices( ( context, services ) =>
        {
            var startUpObj = (typeof( TStartup ).GetConstructor( new[] { typeof( IConfiguration ) } ) != null)
                ? (TStartup) Activator.CreateInstance( typeof( TStartup ), context.Configuration )
                : (TStartup) Activator.CreateInstance( typeof( TStartup ), null );

            var configureMethod = typeof( TStartup ).GetMethod( "ConfigureServices", new[] { typeof( IServiceCollection ) } );
            configureMethod?.Invoke( startUpObj, new object[] { services } );
        } );

        return hostBuilder;
    }
}
