using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TwenGo.Controllers.API;
using TwenGo.Models.Repository;
using TwenGo.Models.Repository.Entity;
using TwenGo.Services;

namespace TwenGo
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
            services.AddDbContext<TwenGoContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TwenGoConnection")));


            //宣告增加驗證方式，使用 cookie 驗證
            services.AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme
                
                //預設的驗證機制,裡面的名字預設叫Cookies
            ).AddCookie(opt => 
            {
                //瀏覽器會限制cookie 只能經由HTTP(S) 協定來存取
                opt.Cookie.HttpOnly = true;
                //未登入時會自動導到這個網址
                opt.LoginPath = new PathString("~/Login/Index");
                //登入有效時間
                opt.ExpireTimeSpan = TimeSpan.FromDays(7);

            }).AddFacebook(opt =>
            {
                opt.AppId = Configuration["Facebook:AppId"];
                opt.AppSecret = Configuration["Facebook:AppSecret"];
                opt.AccessDeniedPath = "/AccessDeniedPathInfo";
            });


            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<Users>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
               
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
               options.SignIn.RequireConfirmedEmail = true;

            })

                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TwenGoContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
            services.AddSession();
           
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Login/Index");
                //other properties
            });
           



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
            app.UseSession();
            app.UseRouting();

            app.UseCookiePolicy();
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
