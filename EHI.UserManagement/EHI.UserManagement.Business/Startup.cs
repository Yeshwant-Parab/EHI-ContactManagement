using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EHI.UserManagement.Repository;
using EHI.UserManagement.Repository.Context;
using EHI.UserManagement.Repository.Interface;
using EHI.UserManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;

namespace EHI.UserManagement.Business
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
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(x => x.AddProfile(new MappingProfiles()));

            services.AddDbContext<DatabaseContext>(options => options.
            UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
