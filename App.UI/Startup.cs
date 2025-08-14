using App.Domain.CommonAppSetting;
using App.Domain.Contexts;
using App.RepositoryLayer.Contract.IAppRepository;
using App.RepositoryLayer.Persistence.AppRepository;
using App.ServiceLayer.Contract.IEntityServices.IExampleServices;
using App.ServiceLayer.Persistence.EntityServices.ExampleService;
using App.ServiceLayer.Persistence.Mapper;
using App.UI.Models.MapperModel;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
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




            #region Auto Mapper Configurations

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new APIAutoMapperProfile());
                mc.AddProfile(new DBAutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Inject Sections of AppSetting,Connectionstring,ConnectionTimeOut

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<ConnectionStringModel>(Configuration.GetSection("ConnectionStrings"));

            services.Configure<ConnectionTimeOutModel>(Configuration.GetSection("ConnectionTimeOut"));




            #endregion


            #region Dependency Injection Of Context and wrapper 

            //DBContext
            services.AddScoped<IBaseContext, BaseContext>();

            //Wrapper
            services.AddScoped<IAppUnitOfWork, AppWrapper>();

            //Services

            services.AddScoped<IExampleService, ExampleService>();





            #endregion








        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
