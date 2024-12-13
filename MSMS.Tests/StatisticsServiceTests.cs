using Microsoft.EntityFrameworkCore;
using Moq;
using MSMS.Core.Contracts;
using MSMS.Core.Services;
using MSMS.Infrastructure.Common;
using MSMS.Infrastructure.Data.Models;
using MSMS.Tests.Extensions;

namespace MSMS.Tests
{
    public class StatisticsServiceTests
    {
        private Mock<IRepository> repositoryMock;
        private IStatisticsService statisticsService;

        [SetUp]
        public void Setup()
        {
            repositoryMock = new Mock<IRepository>();
            statisticsService = new StatisticsService(repositoryMock.Object);
        }

        [Test]
        public async Task RegisteredUsersCountAsync_ReturnsUsersCount()
        {
            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "username",
                NormalizedUserName = "USERNAME",
                Email = "username@mail.com",
                NormalizedEmail = "USERNAME@MAIL.COM",
                FirstName = "First",
                LastName = "Last",
                PasswordHash = "123"
            };

            repositoryMock.Setup(r => r.AllReadOnly<ApplicationUser>())
                .Returns(new List<ApplicationUser> { user }.AsQueryable().BuildMockDbSet().Object);

            int count = await statisticsService.RegisteredUsersCountAsync();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public async Task ServersCountAsync_ReturnsUsersServers()
        {
            var entity = new Server
            {
                Id = 1,
                Name = "Server Name",
                IpAddress = "server.address.com",
                GameVersion = "1.1.1",
                ImagePath = "/",
                PlayMode = Infrastructure.Data.Enums.PlayMode.Adventure,
                OwnerId = "1",
            };

            repositoryMock.Setup(r => r.AllReadOnly<Server>())
                .Returns(new List<Server> { entity }.AsQueryable().BuildMockDbSet().Object);

            int count = await statisticsService.ServersCountAsync();
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
