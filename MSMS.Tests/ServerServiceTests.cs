using NUnit.Framework;
using Moq;
using System;
using System.IO;
using System.Threading.Tasks;
using MSMS.Infrastructure.Common;
using MSMS.Core.Contracts;
using AutoMapper;
using MSMS.Core.Services;
using MSMS.Infrastructure.Data.Models;

[TestFixture]
public class ServerServiceTests
{
    private Mock<IRepository> _mockRepository;
    private Mock<IMapper> _mapperMock;
    private IServerService _serverService;
    private const string DefaultServerImagePath = "server-banners/default.png";

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IRepository>();
        _mapperMock = new Mock<IMapper>();
        _serverService = new ServerService(_mockRepository.Object, _mapperMock.Object);
    }

    [Test]
    public async Task UploadServerBannerAsync_WhenServerDoesNotExist_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var serverId = 999;
        var fileName = "test-banner.png";

        _mockRepository.Setup(r => r.GetByIdAsync<Server>(serverId))
            .ReturnsAsync((Server)null);

        using var serverImageStream = new MemoryStream(new byte[] { 1, 2, 3, 4 });

        // Act & Assert
        var exception = Assert.ThrowsAsync<InvalidOperationException>(
            () => _serverService.UploadServerBannerAsync(serverId, serverImageStream, fileName));

        Assert.That(exception.Message, Is.EqualTo("Server does not exist!"));

        _mockRepository.Verify(r => r.GetByIdAsync<Server>(serverId), Times.Once);
        _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
    }

    [Test]
    public async Task UploadServerBannerAsync_WhenRepositoryThrowsException_ShouldPropagateException()
    {
        // Arrange
        var serverId = 1;
        var fileName = "test-banner.png";
        var expectedException = new Exception("Database connection failed");

        _mockRepository.Setup(r => r.GetByIdAsync<Server>(serverId))
            .ThrowsAsync(expectedException);

        using var serverImageStream = new MemoryStream(new byte[] { 1, 2, 3, 4 });

        // Act & Assert
        var exception = Assert.ThrowsAsync<Exception>(
            () => _serverService.UploadServerBannerAsync(serverId, serverImageStream, fileName));

        Assert.That(exception.Message, Is.EqualTo("Database connection failed"));

        _mockRepository.Verify(r => r.GetByIdAsync<Server>(serverId), Times.Once);
        _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Never);
    }

    [TearDown]
    public void TearDown()
    {
        _mockRepository?.Reset();
    }
}
