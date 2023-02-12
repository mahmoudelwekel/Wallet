using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.UI.Models.MapperModel;
using Wallet.Domain.Common.APPSetting;
using Wallet.Domain.Contexts;
using Wallet.RepositoryLayer.Contract.IWalletRepository;
using Wallet.RepositoryLayer.Persistence.WalletRepository;
using Wallet.ServiceLayer.Contract.IEntityServices.ITransactionServices;
using Wallet.ServiceLayer.Persistence.EntityServices.TransactionService;
using Wallet.ServiceLayer.Persistence.Mapper;
using Wallet.UI.Data;

namespace Wallet
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();




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
            services.AddScoped<IWalletWrapper, WalletWrapper>();
 
            //Services
           
            services.AddScoped<ITransactionEntityService, TransactionEntityService>();
 


             

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
