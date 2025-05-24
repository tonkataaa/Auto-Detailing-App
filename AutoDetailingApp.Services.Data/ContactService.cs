namespace AutoDetailingApp.Services.Data
{
	using System.Threading.Tasks;

	using AutoDetailingApp.Models;
	using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Services.Data.Interfaces;
	using AutoDetailingApp.Data.Repository.Interfaces;

	public class ContactService : IContactService
	{
		private readonly IRepository<ContactRequest, Guid> contactRepository;

		public ContactService(IRepository<ContactRequest, Guid> contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		public async Task SubmitContactRequestAsync(ContactFormModel model)
		{
			var contactRequest = new ContactRequest()
			{
				FullName = model.Name,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				Message = model.Question,
				CreatedAt = DateTime.Now
			};

			await contactRepository.AddAsync(contactRequest);
		}
	}
}
