using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetRendition;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetRendition;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Tests.Services.AssetRendition
{
    public class InsertAssetRenditionCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAssetRenditionRepository> _repositoryMock;
        private readonly Mock<ILogger<AssetRenditionService>> _loggerMock;
        private readonly AssetRenditionService _service;
        public InsertAssetRenditionCommandTests()
        {
            _repositoryMock = new Mock<IAssetRenditionRepository>();
            _loggerMock = new Mock<ILogger<AssetRenditionService>>();
            _service = new AssetRenditionService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AssetRenditionDto>("tr");
            var fakeResponse = new RepoResponse<AssetRenditionDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AssetRenditionDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<AssetRenditionDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AssetRenditionDto>("tr");
            var fakeResponse = new RepoResponse<AssetRenditionDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AssetRenditionDto>())).ReturnsAsync(fakeResponse);
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