using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DBContext;

namespace WpfApp1
{
    public static class IoCContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IDbContext, AppDbContext>();
        }
    }
}
