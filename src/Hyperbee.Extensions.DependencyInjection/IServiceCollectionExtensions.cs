using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hyperbee.Extensions.DependencyInjection;

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions
{
    public static void RegisterTypesThatClose( this IServiceCollection services, Type openType, ServiceLifetime lifetime, Assembly assembly = null )
    {
        ArgumentNullException.ThrowIfNull( services );

        ArgumentNullException.ThrowIfNull( openType );

        if ( !openType.IsGenericTypeDefinition || !openType.ContainsGenericParameters ) // must be an open generic
            throw new ArgumentException( "Type must be an open generic.", nameof(openType) );

        // scan
        assembly ??= Assembly.GetCallingAssembly();

        foreach ( var implementationType in assembly.GetTypes().Where( x => x.IsClass && !x.IsAbstract ) ) // only consider non-abstract classes
        {
            var matchingOpenInterfaces = implementationType
                .GetInterfaces()
                .Where( x => x.IsGenericType && x.GetGenericTypeDefinition() == openType )
                .Distinct();

            foreach ( var match in matchingOpenInterfaces )
            {
                // Microsoft DI cannot register an open generic interface without a matching
                // open generic implementation. Close the open interface so we can register.

                var serviceType = openType.MakeGenericType( match.GetGenericArguments() );

                var descriptor = new ServiceDescriptor( serviceType, implementationType, lifetime );
                services.Add( descriptor );
            }
        }
    }
}