using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sol_Demo.Models;
using Sol_Demo.Models.ChildPoco;
using Sol_Demo.Models.UsersPoco;
using Sol_Demo.Models.Validator;
using Sol_Demo.Models.Validator.ParentChildDemo;
using Sol_Demo.Models.Validator.UsersDemo;
using Sol_Demo.ViewModels;

namespace Sol_Demo
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
            services
                .AddControllersWithViews()
                .AddFluentValidation(fv =>
                {
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.ImplicitlyValidateChildProperties = true;
                });

            services.AddTransient<IValidator<UserCommunicationModel>, UserCommunicationModelValidator>();
            services.AddTransient<IValidator<UserModel>, UserModelValidator>();
            services.AddTransient<IValidator<UsersViewModel>, UserViewModelValidator>();

            services.AddTransient<IValidator<ChildModel>, ChildModelValidator>();
            services.AddTransient<IValidator<ParentModel>, ParentModelValidator>();
            services.AddTransient<IValidator<ParentChildViewModel>, ParentChildViewModelValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ParentChildDemo}/{action=Index}/{id?}");
            });
        }
    }
}
