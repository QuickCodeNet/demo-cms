using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.AssetManagementModule.Application.Services.AssetMetadatum;
using QuickCode.DemoCms.AssetManagementModule.Application.Dtos.AssetMetadatum;
using QuickCode.DemoCms.AssetManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.AssetManagementModule.Application.Tests.Services.AssetMetadatum
{
    public class AssetMetadatumServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IAssetMetadatumRepository> _repositoryMock;
        private readonly Mock<ILogger<AssetMetadatumService>> _loggerMock;
        private readonly AssetMetadatumService _service;
        public AssetMetadatumServiceDeleteTests()
        {
            _repositoryMock = new Mock<IAssetMetadatumRepository>();
            _loggerMock = new Mock<ILogger<AssetMetadatumService>>();
            _service = new AssetMetadatumService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<AssetMetadatumDto>("tr");
            var fakeGetResponse = new RepoResponse<AssetMetadatumDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<AssetMetadatumDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<AssetMetadatumDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<AssetMetadatumDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<AssetMetadatumDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.Id);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<AssetMetadatumDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}