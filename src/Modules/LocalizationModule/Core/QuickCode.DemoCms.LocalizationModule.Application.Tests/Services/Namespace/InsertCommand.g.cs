using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.LocalizationModule.Application.Services.Namespace;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.Namespace;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.LocalizationModule.Application.Tests.Services.Namespace
{
    public class InsertNamespaceCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<INamespaceRepository> _repositoryMock;
        private readonly Mock<ILogger<NamespaceService>> _loggerMock;
        private readonly NamespaceService _service;
        public InsertNamespaceCommandTests()
        {
            _repositoryMock = new Mock<INamespaceRepository>();
            _loggerMock = new Mock<ILogger<NamespaceService>>();
            _service = new NamespaceService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<NamespaceDto>("tr");
            var fakeResponse = new RepoResponse<NamespaceDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<NamespaceDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<NamespaceDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<NamespaceDto>("tr");
            var fakeResponse = new RepoResponse<NamespaceDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<NamespaceDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.Null(result.Value);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}