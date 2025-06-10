using AutoDetailingApp.Areas.Identity.Services;
using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Mail;

public class TestStartup
{
    public IConfiguration Configuration { get; }

    public TestStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration["SQLServer:ConnectionString"];
        services.AddDbContext<AutoDetailingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddSingleton(new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(
                "shikagamingbg@gmail.com",
                "ulaz cgqo bwoj puma"
            ),
            EnableSsl = true
        });

        services.AddSingleton<IEmailSender, EmailSender>();

        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddRazorPages();

        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
        {
            ConfigureIdentity(options);
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<AutoDetailingDbContext>()
        .AddDefaultTokenProviders();

        services.AddControllersWithViews();
        services.AddApplicationServices();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Admin/Home/Index";
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
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
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapRazorPages();
        });
    }

    private void ConfigureIdentity(IdentityOptions options)
    {
        options.Password.RequireDigit = Configuration.GetValue<bool>("IdentityOptions:Password:RequireDigits");
        options.Password.RequiredLength = Configuration.GetValue<int>("IdentityOptions:Password:RequireLength");
        options.Password.RequireNonAlphanumeric = Configuration.GetValue<bool>("IdentityOptions:Password:RequireNonAlphanumeric");
        options.Password.RequireUppercase = Configuration.GetValue<bool>("IdentityOptions:Password:RequireUppercase");
        options.Password.RequireLowercase = Configuration.GetValue<bool>("IdentityOptions:Password:RequireLowercase");

        options.SignIn.RequireConfirmedAccount = Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
        options.SignIn.RequireConfirmedEmail = Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
        options.SignIn.RequireConfirmedPhoneNumber = Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

        options.User.RequireUniqueEmail = Configuration.GetValue<bool>("IdentityOptions:User:RequireUniqueEmail");
    }
}
