using Lamar.Scanning.Conventions;
using Microsoft.Extensions.Configuration;

namespace Hyperbee.Extensions.Lamar;

public static class AssemblyScannerExtensions
{
    public static void LookForStartupRegistries( this IAssemblyScanner scanner, IConfiguration configuration )
    {
        var convention = new FindStartupRegistriesScanner { Configuration = configuration };
        scanner.With( convention );
    }
}
