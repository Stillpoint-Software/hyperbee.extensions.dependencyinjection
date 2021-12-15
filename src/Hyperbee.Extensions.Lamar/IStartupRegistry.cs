using Lamar;

namespace Hyperbee.Extensions.Lamar;

public interface IStartupRegistry
{
    public void ConfigureContainer( ServiceRegistry services );
}