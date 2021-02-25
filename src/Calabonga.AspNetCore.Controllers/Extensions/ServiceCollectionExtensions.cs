using System;
using System.Linq;
using System.Reflection;
using Calabonga.Microservices.Core.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Calabonga.AspNetCore.Controllers.Extensions
{
    /// <summary>
    /// Service Collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registration for Mediator and for CRUD operations
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        public static void AddCommandAndQueries(this IServiceCollection services, Assembly assembly)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && (x.FullName.StartsWith("Calabonga.AspNetCore.Controllers") ||
                                                   x.FullName.StartsWith("MediatR")))
                .ToList();

            var all = assemblies.Append(assembly).ToList();
            services.AddMediatR(all.ToArray());
            var types = all.SelectMany(x => x.DefinedTypes).Where(t => t.IsClass && !t.IsAbstract).ToList();
            foreach (var type in types)
            {
                foreach (var i in type.GetInterfaces())
                {
                    if (!i.IsGenericType || i.GetGenericTypeDefinition() != typeof(IRequestHandler<,>))
                    {
                        continue;
                    }

                    var inhered = types.FirstOrDefault(t => t.IsSubclassOf(i.GetGenericArguments()[0]));
                    if (inhered == null)
                    {
                        var self = i.GetGenericArguments()[0];
                        if (self.FullName == null)
                        {
                            throw new MicroserviceException($"IRequestHandler not found for {i.GetGenericArguments()[0].FullName}");
                        }

                        inhered = self.GetTypeInfo();
                    }
                    var interfaceType1 = typeof(IRequestHandler<,>).MakeGenericType(inhered, i.GetGenericArguments()[1]);
                    services.AddTransient(interfaceType1, type);
                }
            }
        }
    }
}
