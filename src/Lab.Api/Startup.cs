using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Lab.Business;
using Lab.Repository;
using Lab.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Lab.Api
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors();
            services.AddControllers();
            services.AddTransient<IBusinessProduto, BusinessProduto>();
            services.AddTransient<IBusinessCategoria, BusinessCategoria>();
            services.AddTransient<ICategoria, CategoriaRepository>();
            services.AddTransient<IProduto, ProdutoRepository>();
            services.AddDbContext<Contexto>(c => c.UseInMemoryDatabase(databaseName: "Demo"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(op =>
            {
                op.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
                 
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
