using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using MusicMarket.Core.Repositories;
using MusicMarket.Core.Services;
using MusicMarket.Data;
using MusicMarket.Data.Repositories;
using MusicMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MusicMarket.API
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

            //Singleton : uygulama ilk aya�a kalkt��� anda, servisin tek bir instance�� olu�turularak memory�de tutulur
            //ve daha sonras�nda her servis �a�r�s�nda bu instance g�nderilir.

            //Scoped : her request i�in tek bir instance yarat�lmas�n� sa�layan lifetime se�ene�idir.
            //Request cycle�� tamamlanana kadar ger�ekle�en servis �a�r�lar�nda daha �nce olu�turulan instance g�nderilir.
            //Daha sonra yeni bir request ba�lad���nda farkl� bir instance olu�turulur.

            //Transient : her servis �a�r�s�nda yeni bir instance olu�turulur. ba�lay�c�l��� en az olan lifetime se�ene�idir.

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IArtistService, ArtistService>();

            services.AddDbContext<MusicMarketDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"), x =>
             x.MigrationsAssembly("MusicMarket.Data")));

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Market", Version = "v1" });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger(); app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Market V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
