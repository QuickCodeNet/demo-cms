using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.SiteLanguage;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Tests.Services.SiteLanguage
{
    public class UpdateSiteLanguageCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ISiteLanguageRepository> _repositoryMock;
        private readonly Mock<ILogger<SiteLanguageService>> _loggerMock;
        private readonly SiteLanguageService _service;
        public UpdateSiteLanguageCommandTests()
        {
            _repositoryMock = new Mock<ISiteLanguageRepository>();
            _loggerMock = new Mock<ILogger<SiteLanguageService>>();
            _service = new SiteLanguageService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<SiteLanguageDto>("tr");
            var fakeGetResponse = new RepoResponse<SiteLanguageDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.SiteId, fakeDto.LanguageId)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<SiteLanguageDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.SiteId, fakeDto.LanguageId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.SiteId, fakeDto.LanguageId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<SiteLanguageDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<SiteLanguageDto>("tr");
            var fakeGetResponse = new RepoResponse<SiteLanguageDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.SiteId, fakeDto.LanguageId)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.SiteId, fakeDto.LanguageId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.SiteId, fakeDto.LanguageId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<SiteLanguageDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}