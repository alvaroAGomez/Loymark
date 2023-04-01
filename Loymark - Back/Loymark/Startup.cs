using Loymark.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using AutoMapper;
using Loymark.Helpers;

namespace Loymark
{
    public class Startup
    {
        private readonly CorsOptions _corsOptions = new CorsOptions();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection(CorsOptions.SectionName).Bind(_corsOptions);
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(_corsOptions.UrlWeb)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Loymark", Version = "v1" });
            });

            string ConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<LoymarkContext>(options => options.UseSqlServer(ConnectionStr));
            services.AddControllers();

            AddDependences(services);
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureServiceDependencies();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loymark v1"));
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddDependences(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
