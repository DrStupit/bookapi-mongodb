using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookApi
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
            services.Configure<BookstoreDatabaseSettings>( Configuration.GetSection(nameof(BookstoreDatabaseSettings)));
            services.Configure<JobPostDatabseSettings>(Configuration.GetSection(nameof(JobPostDatabseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
            services.AddSingleton<IJobPostDatabseSettings>(sp => sp.GetRequiredService<IOptions<JobPostDatabseSettings>>().Value);

            services.AddSingleton<BookService>();
            services.AddSingleton<JobpostService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}