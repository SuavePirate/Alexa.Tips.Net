using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractingSamples.Contexts;
using AbstractingSamples.Handlers.Definition;
using AbstractingSamples.Handlers.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AbstractingSamples
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add other dependencies first
            services.AddDbContext<SampleMessageDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // Register your handlers here!
            services.AddScoped<ICollection<IHandler>>(s =>
            {
                // get the db context to inject in the handlers that are dependent
                var dbContext = s.GetRequiredService<SampleMessageDbContext>();
                return new List<IHandler>
                {
                    new SimpleLaunchHandler(),
                    new DogFactHandler(),
                    new SampleFactHandler(dbContext)
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
