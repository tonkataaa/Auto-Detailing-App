
namespace AutoDetailingApp.Services.Data.Interfaces
{
    using AutoDetailingApp.Web.ViewModels;

    public interface IContactService
    {
        Task SubmitContactRequestAsync(ContactFormModel model);
    }
}
