using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetTranslation;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetTranslation;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Tests.Services.AssetTranslation
{
    public class InsertAssetTranslationCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAssetTranslationRepository> _repositoryMock;
        private readonly Mock<ILogger<AssetTranslationService>> _loggerMock;
        private readonly AssetTranslationService _service;
        public InsertAssetTranslationCommandTests()
        {
            _repositoryMock = new Mock<IAssetTranslationRepository>();
            _loggerMock = new Mock<ILogger<AssetTranslationService>>();
            _service = new AssetTranslationService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AssetTranslationDto>("tr");
            var fakeResponse = new RepoResponse<AssetTranslationDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AssetTranslationDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<AssetTranslationDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AssetTranslationDto>("tr");
            var fakeResponse = new RepoResponse<AssetTranslationDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<AssetTranslationDto>())).ReturnsAsync(fakeResponse);
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