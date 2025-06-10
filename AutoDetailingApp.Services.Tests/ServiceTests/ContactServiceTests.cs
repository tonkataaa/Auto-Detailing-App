namespace AutoDetailingApp.Services.Tests.ServiceTests
{
    using Xunit;
    using Moq;

    using AutoDetailingApp.Services.Data;
    using AutoDetailingApp.Models;
    using AutoDetailingApp.Data.Repository.Interfaces;
    using AutoDetailingApp.Web.ViewModels;
    using System.Threading.Tasks;

    public class ContactServiceTests
    {
        [Fact]
        public async Task ContactService_ShouldSubmitRequestSuccessfully()
        {
            //Arrange
            var contactRepositoryMock = new Mock<IRepository<ContactRequest, Guid>>();

            contactRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<ContactRequest>()))
                .Returns(Task.CompletedTask);

            var contactService = new ContactService(contactRepositoryMock.Object);

            var validModel = new ContactFormModel
            {
                Name = "Jackie Chan",
                Email = "john@example.com",
                PhoneNumber = "+1234567890",
                Question = "What is the price for a full car detailing?",
                CreatedAt = DateTime.Now
            };

            
            //Act
            await contactService.SubmitContactRequestAsync(validModel);

            //Assert
            contactRepositoryMock.Verify(repo => repo.AddAsync(It.Is<ContactRequest>(cr =>
                cr.FullName == validModel.Name &&
                cr.Email == validModel.Email &&
                cr.PhoneNumber == validModel.PhoneNumber &&
                cr.Message == validModel.Question &&
                cr.CreatedAt.Date == validModel.CreatedAt.Date
            )), Times.Once);
        }
    }
}
