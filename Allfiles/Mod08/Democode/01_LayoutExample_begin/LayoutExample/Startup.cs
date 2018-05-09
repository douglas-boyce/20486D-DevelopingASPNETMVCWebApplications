﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LayoutExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StudentContext>(options =>
                   options.UseInMemoryDatabase("StudentDB"));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "StudentRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Student", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
