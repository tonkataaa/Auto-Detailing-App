namespace AutoDetailingApp.Data.Seeding
{
	using AutoDetailingApp.Models;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Options;

	public class DbSeeder
	{
		public static async Task CreateAdminWithRoleAsync(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var configuration = serviceProvider.GetRequiredService<IConfiguration>();

			var adminEmail = configuration["Admin:Email"];
			var adminPassword = configuration["Admin:Password"];

			var roleExist = await roleManager.RoleExistsAsync("Admin");
			var userExist = await userManager.FindByEmailAsync(adminEmail);

			if (!roleExist)
			{
				await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
			}

			if (userExist == null)
			{
				var user = new ApplicationUser
				{
					UserName = adminEmail,
					Email = adminEmail,
					PasswordHash = adminPassword
				};

				var result = await userManager.CreateAsync(user, "admin");
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
			}
		}
	}

}
