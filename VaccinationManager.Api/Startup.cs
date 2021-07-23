using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.DAL;
using VaccinationManager.Services;
using Newtonsoft;
using System.Text.Json.Serialization;
using VaccinationManager.Services.Center;
using VaccinationManager.Services.Adresse;
using VaccinationManager.Services.Personnes;
using VaccinationManager.Services.Rendez_vous;
using VaccinationManager.Services.Vaccin;
using VaccinationManager.Models.Vaccin;

namespace VaccinationManager.Api
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
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VaccinationManager")));

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            //Add services

//Center            
services.AddScoped<VaccinationCenterService>();
            services.AddScoped<ScheduleCenterService>();
            //Adresse
            services.AddScoped<AdressService>();

            //Personnes
            services.AddScoped<PersonService>();
            services.AddScoped<StaffService>();
            services.AddScoped<MedicalStaffService>();
            services.AddScoped<PatientService>();

            //Rendez-vous
            services.AddScoped<AppointmentService>();

            //Vaccin
            services.AddScoped<VaccinLotService>();
            services.AddScoped<VaccinProviderService>();
            services.AddScoped<VaccinTypeService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VaccinationManager.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VaccinationManager.Api v1"));
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
