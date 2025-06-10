namespace AutoDetailingApp.Services.Tests.ServiceTests
{
    using Xunit;
    using Moq;

    using AutoDetailingApp.Services.Data;
    using AutoDetailingApp.Models;
    using AutoDetailingApp.Data.Repository.Interfaces;
    using AutoDetailingApp.Web.ViewModels;
    using System.Threading.Tasks;
    using AutoDetailingApp.Web.ViewModels.Reservation;

    public class ReservationServiceTests
    {
        private Mock<IRepository<Appointment, Guid>> reservationRepositoryMock;
        private Mock<IRepository<Service, Guid>> serviceRepositoryMock;

        public ReservationServiceTests()
        {
            this.reservationRepositoryMock = new Mock<IRepository<Appointment, Guid>>();
            this.serviceRepositoryMock = new Mock<IRepository<Service, Guid>>();
        }

        [Fact]
        public async Task GetAvailableHours_ShouldReturn_AllHours()
        {
            //Arrange
            var reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                serviceRepositoryMock.Object);  

            //Act
            reservationService.GetAvailableHours();

            //Assert
            var expectedHours = new List<string> { "8:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            var actualHours = reservationService.GetAvailableHours().Select(h => h.Text).ToList();
            Assert.Equal(expectedHours, actualHours);
        }

        [Fact]
        public async Task GetAvailableServicesAsync_ShouldReturn_AllServices()
        {
            // Arrange
            var services = new List<Service>
            {
                new Service { Id = Guid.NewGuid(), Name = "Full Car Detailing", Price = 100.00m },
                new Service { Id = Guid.NewGuid(), Name = "Interior Cleaning", Price = 50.00m }
            };
            serviceRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(services);
            var reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                serviceRepositoryMock.Object);

            // Act
            var result = await reservationService.GetAvailableServicesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Text == "Full Car Detailing");
            Assert.Contains(result, s => s.Text == "Interior Cleaning");
        }

        [Fact]
        public async Task ReservationShouldBeCreatedCorrectly()
        {
            // Arrange
            var userId = Guid.NewGuid(); 

            var validModel = new ReservationFormModel
            {
                FullName = "Jackie Chan",
                PhoneNumber = "+1234567890",
                Email = "jackieChan@test.com",
                DateForReservation = DateTime.UtcNow.AddDays(1),
                ServiceId = Guid.NewGuid(),
                Comment = "Test",
                CreatedAt = DateTime.UtcNow
            };

            var testService = new Service
            {
                Id = validModel.ServiceId,
                Name = "Full Car Detailing",
                Price = 100.00m,
            };

            var reservationRepositoryMock = new Mock<IRepository<Appointment, Guid>>();
            var serviceRepositoryMock = new Mock<IRepository<Service, Guid>>();

            reservationRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Appointment>()))
                .Returns(Task.CompletedTask);

            serviceRepositoryMock
                .Setup(repo => repo.GetByIdAsync(validModel.ServiceId))
                .ReturnsAsync(testService);

            var reservationService = new ReservationService(
                reservationRepositoryMock.Object,
                serviceRepositoryMock.Object);

            // Act
            var result = await reservationService.TryCreateReservationAsync(validModel, userId.ToString());

            // Assert
            Assert.True(result);

            reservationRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Appointment>(a =>
                a.FullName == validModel.FullName &&
                a.PhoneNumber == validModel.PhoneNumber &&
                a.Email == validModel.Email &&
                a.DateTime.Date == validModel.DateForReservation.Date &&
                a.ServiceId == validModel.ServiceId &&
                a.Comment == validModel.Comment &&
                a.CreatedAt.Date == validModel.CreatedAt.Date &&
                a.UserId == userId
            )), Times.Once);
        }
    }
}
