
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using AutoDetailingApp.Web.Infrastructure;
using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using AutoDetailingApp.Data.Repository.Interfaces;
using AutoDetailingApp.Data.Repository;
using AutoDetailingApp.Services.Data.Interfaces;
using AutoDetailingApp.Services.Data;
using AutoDetailingApp.Web.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var config = new ConfigurationBuilder()
	.AddJsonFile($"appsettings.json", true, true)
	.AddEnvironmentVariables()
	.AddUserSecrets<Program>()
	.Build();
builder.Services.AddDbContext<AutoDetailingDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var identityConfig = builder.Configuration.GetSection("IdentityOptions");
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
	ConfigureIdentity(builder, options);        
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<AutoDetailingDbContext>()
.AddDefaultUI()
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddUserManager<UserManager<ApplicationUser>>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Admin/Home/Index";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
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

//Adding Admin
//using (var scope = app.Services.CreateScope())
//{
//	var services = scope.ServiceProvider;
//	await DbSeeder.CreateAdminWithRoleAsync(services);
//}

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions cfg)
{
	cfg.Password.RequireDigit =
		builder.Configuration.GetValue<bool>("IdentityOptions:Password:RequireDigits");
	cfg.Password.RequiredLength =
		builder.Configuration.GetValue<int>("IdentityOptions:Password:RequireLength");
	cfg.Password.RequireNonAlphanumeric =
		builder.Configuration.GetValue<bool>("IdentityOptions:Password:RequireNonAlphanumeric");
	cfg.Password.RequireUppercase =
		builder.Configuration.GetValue<bool>("IdentityOptions:Password:RequireUppercase");
	cfg.Password.RequireLowercase =
		builder.Configuration.GetValue<bool>("IdentityOptions:Password:RequireLowercase");

	cfg.SignIn.RequireConfirmedAccount =
		builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
	cfg.SignIn.RequireConfirmedEmail =
		builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
	cfg.SignIn.RequireConfirmedPhoneNumber =
		builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

	cfg.User.RequireUniqueEmail =
		builder.Configuration.GetValue<bool>("IdentityOptions:User:RequireUniqueEmail");
}
