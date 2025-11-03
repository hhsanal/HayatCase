using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationRegister
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(conf =>{
                conf.RegisterServicesFromAssembly(typeof(ApplicationRegister).Assembly);
            });

            return services;
        }
    }
}
