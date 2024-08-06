using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Repository.Data;

namespace Vezzeta.Repository.DI
{
    public static class RepoLayerServices
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services,)
        {
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer());
            return services;
        }
    }
}
