using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace AutoDetailingApp.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
		}
	}
}
