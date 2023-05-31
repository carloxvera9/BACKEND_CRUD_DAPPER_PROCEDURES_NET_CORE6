using Dominio.Infraestructura.Repositories;
using Dominio.Interface.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Infraestructura
{
    public static class DependendyInjection
    {
        public static IServiceCollection agregarInfrastructura ( this IServiceCollection services)
        {
            services.AddTransient<ILibrosRepository, LibrosRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
