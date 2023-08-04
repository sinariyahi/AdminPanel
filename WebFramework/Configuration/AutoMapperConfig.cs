using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using Domain.Common;

namespace WebFramework.Configuration;

public static class AutoMapperConfig
{
    public static  void RegisterAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {        
        services.AddAutoMapper(config =>
        {
            config.AddCustomMappingProfile();
            config.Advanced.BeforeSeal(configProvicer =>
            {
                configProvicer.CompileMappings();
            });
        }, assemblies);
    }
    public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
    {
        var customMapping = typeof(IHaveCustomMapping).Assembly;
        //config.AddCustomMappingProfile(Assembly.GetEntryAssembly());
        config.AddCustomMappingProfile(customMapping);
    }
    public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
    {
        var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

        var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
            type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
            .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

        var profile = new CustomMappingProfile(list);

        config.AddProfile(profile);
    }
}

