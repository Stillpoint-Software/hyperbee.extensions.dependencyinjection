using JasperFx.Core.TypeScanning;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.Configuration;

namespace Hyperbee.Extensions.Lamar;

internal class FindStartupRegistriesScanner : IRegistrationConvention
{
    public IConfiguration Configuration { get; set; }

    public void ScanTypes( TypeSet types, ServiceRegistry registry )
    {
        foreach ( var type in types.FindTypes( TypeClassification.Closed | TypeClassification.Concretes ) )
        {
            if ( RegistryHelper.IsStartupRegistry( type ) )
                RegistryHelper.IncludeStartupRegistry( registry, type, Configuration );
        }
    }
}
