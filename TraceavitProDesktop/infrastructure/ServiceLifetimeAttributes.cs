using System;
using Microsoft.Extensions.DependencyInjection;
using TraceavitProDesktop.models;

namespace TraceavitProDesktop.infrastructure;

public static class ServiceLifetimeAttributes
{
    /// <summary>
    /// Сканирует и регестрирует сервисы, в соответствии с временем жизни
    /// </summary>
    /// <param name="collection"></param>
    public static void AddServices(this IServiceCollection collection)
    {
        collection.Scan(scan =>
            {
                scan.
                    FromEntryAssembly().
                    FromApplicationDependencies().
                    
                    AddClasses(classes => { classes.WithAttribute<SingletonServiceAttribute>(); }).
                    AsSelf().WithSingletonLifetime().
                    
                    AddClasses(classes => { classes.WithAttribute<TransientServiceAttribute>(); }).
                    AsSelf().WithTransientLifetime().
                    
                    AddClasses(classes => { classes.WithAttribute<ScopedServiceAttribute>(); }).
                    AsSelf().WithScopedLifetime();
            }
        );
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class SingletonServiceAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class)]
public class TransientServiceAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Class)]
public class ScopedServiceAttribute : Attribute
{
}