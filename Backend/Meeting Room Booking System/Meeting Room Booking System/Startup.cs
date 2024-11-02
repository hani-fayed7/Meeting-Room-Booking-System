using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using MRBS.Core.Repositories;
using MRBS.Services;
using MRBS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meeting_Room_Booking_System
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
            services.AddDbContext<meetingRoomBookingSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MRBS.Core")));
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meeting_Room_Booking_System", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting_Room_Booking_System v1"));
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
