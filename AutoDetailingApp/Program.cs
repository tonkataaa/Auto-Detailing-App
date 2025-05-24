using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using System.Reflection;
using AutoDetailingApp.Data.Repository.Interfaces;
using AutoDetailingApp.Data.Repository;
using AutoDetailingApp.Services.Data.Interfaces;
using AutoDetailingApp.Services.Data;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AutoDetailingDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 12;               
	options.Password.RequireNonAlphanumeric = true;    
	options.Password.RequireUppercase = true;          
	options.Password.RequireLowercase = true;          
})
.AddEntityFrameworkStores<AutoDetailingDbContext>()
.AddDefaultUI()
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddUserManager<UserManager<ApplicationUser>>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IRepository<Service, Guid>, BaseRepository<Service, Guid>>();
builder.Services.AddScoped<IReservationService, ReservationService>();

var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("bg-BG"),
	SupportedCultures = new[] { new CultureInfo("bg-BG") },
	SupportedUICultures = new[] { new CultureInfo("bg-BG") }
});

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();