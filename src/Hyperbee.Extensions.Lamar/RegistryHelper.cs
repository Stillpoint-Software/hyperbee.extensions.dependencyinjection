using JasperFx.Core.Reflection;
using Lamar;
using Microsoft.Extensions.Configuration;
using System;

namespace Hyperbee.Extensions.Lamar;

internal static class RegistryHelper
{
    internal static bool IsStartupRegistry( Type type )
    {
        if ( Equals( type.Assembly, typeof( IStartupRegistry ).Assembly ) )
            return false;

        return typeof( IStartupRegistry ).IsAssignableFrom( type ) &&
               !type.IsInterface && !type.IsAbstract && !type.IsGenericType;
    }

    internal static void IncludeStartupRegistry( ServiceRegistry registry, Type type, IConfiguration configuration )
    {
        if ( type.GetConstructor( new[] { typeof( IConfiguration ) } ) == null )
            return;

        var startup = Activator.CreateInstance( type, configuration )!.As<IStartupRegistry>();

        var childRegistry = new ServiceRegistry();
        startup.ConfigureContainer( childRegistry );

        registry.IncludeRegistry( childRegistry );
    }
}