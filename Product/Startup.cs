using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Product.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Product.Repository.RepositoryInterface;
using Product.Repository.Repository;
using Product.Service.ServiceInterface;
using Product.Service.Service;
using System;

namespace Product
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().
              AllowAnyHeader());
            });
 
            services.AddControllers();
            services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbConnection"))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Dependency Injection
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService,ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
