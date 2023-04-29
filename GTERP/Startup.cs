#region Using Derective
using GTERP.BLL;
using GTERP.Models;
using GTERP.Models.Common;
using GTERP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using static GTERP.Controllers.HR.DashboardController;
//using AlanJuden.MvcReportViewer;
#endregion

namespace GTERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<GTRDBContext>(options =>
            //options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthPolicyProvider>();

            //services.AddSingleton<IAuthorizationHandler, OverridableAuthorize>();
            //services.AddSingleton<Attribute, OverridableAuthorize>();
            //            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    if (!optionsBuilder.IsConfigured)
            //    {
            //        optionsBuilder.UseSqlServer(@"Data Source=MNILAY-ENVY\\SQLEXPRESS;Initial Catalog=TutorialsTeam;Integrated Security=True");
            //    }
            //}





            services.AddDbContext<GTERP.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<GTRDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            //services.AddDbContext<GTRDBContext>(options => options.UseSqlServer(
            //    this.Configuration.GetConnectionString("DefaultConnection"),
            //    sqlServerOptions => sqlServerOptions.CommandTimeout(300))
            //);

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

            })
                .AddEntityFrameworkStores<GTERP.Data.ApplicationDbContext>();
            //services.ConfigureApplicationCookie(op => {
            // //   op.Cookie.Expiration = TimeSpan.FromSeconds(5); 
            //    op.ExpireTimeSpan= TimeSpan.FromSeconds(5);
            //    op.LoginPath = "/Account/LogIn1";
            //});
            services.AddControllersWithViews();
            services.AddSingleton<IConfiguration>(Configuration);
            // IMvcBuilder mvcBuilder

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            //services.AddScoped<CommercialRepository>();
            services.AddScoped<WebHelper>();
            services.AddScoped<AttendanceRepository>();
            services.AddScoped<HrRepository>();
            services.AddScoped<PayrollRepository>();
            services.AddScoped<clsConnectionNew>();
            services.AddScoped<clsProcedure>();
            services.AddScoped<POSRepository>();
            services.AddScoped<ProductSerialtemp>();
            services.AddScoped<Dashboard>();
            services.AddScoped<DailyAttendanceSum>();
            services.AddScoped<MonthlyAttendance>();
            services.AddScoped<DailyAttendance>();
            services.AddScoped<SalaryDetails>();
            services.AddScoped<EmployeeDetails>();
            services.AddScoped<TransactionLogRepository>();
            services.AddScoped<PermissionLevel>();
            //services.AddTransient<UserLogingInfo>();
            //services.AddScoped<UserLog>();
            //services.AddTransient<AuthorizationFilterContext>();
            //services.AddTransient<ActionContext>();

            //services.AddDetection();///stop by fahad
            //services.AddDetectionCore().AddBrowser();//stop by fahad
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(240);//You can set Time   
                //options.Cookie.Path = "/Account/LogIn1";
            });

            services.Configure<FormOptions>(options =>
            {
                //options.MultipartBodyLengthLimit = 52428800;
                options.ValueCountLimit = 6200;  //// baper beta saddam

            });



            services.AddMvc();

            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddControllers().AddJsonOptions(options =>
            {

                // Use the default property (Pascal) casing.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.FormFieldName = "GTR_ANTIFORZERY";
                options.HeaderName = "X-CSRF-TOKEN-GTR_ANTIFORZERY";
                options.SuppressXFrameOptionsHeader = false;
            });
            IMvcBuilder builder = services.AddRazorPages();
            builder.AddRazorRuntimeCompilation();
            //#if DEBUG
            //            if (Env.IsDevelopment())
            //                        {

            //                        }
            //            #endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseSession();


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
