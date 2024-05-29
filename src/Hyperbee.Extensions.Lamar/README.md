
# Hyperbee Extensions Lamar

The Hyperbee Extensions Lamar contains Lamar service registration helpers for dependency injection.  Lamar maximizes compliance with the underlying IoC behavior assumed by ASP.Net Core. 

# Example

## Program File
```csharp

 var host = Host.CreateDefaultBuilder( args )
                .UseLamar()
                .ConfigureWebHostDefaults( builder =>
                {
                    builder
                        .UseStartup<Startup>();
                } )
                .Build();

            // run
            await host.RunAsync();
```

## Startup File
```csharp
 public void ConfigureContainer( ServiceRegistry services )
    {
        // auto-registrations by convention

        services.Scan( _ =>
        {
            _.TheCallingAssembly();
            _.WithDefaultConventions();
            _.ConnectImplementationsToTypesClosing( typeof( IValidator<> ), ServiceLifetime.Transient );
        } );

        services.AddHttpContextAccessor();

        // additional registrations here
    }
```