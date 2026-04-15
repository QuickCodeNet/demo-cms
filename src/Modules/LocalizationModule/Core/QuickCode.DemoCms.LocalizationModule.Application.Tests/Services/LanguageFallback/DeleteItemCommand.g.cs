using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.LocalizationModule.Application.Services.LanguageFallback;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.LanguageFallback;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.LocalizationModule.Application.Tests.Services.LanguageFallback
{
    public class LanguageFallbackServiceDeleteTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ILanguageFallbackRepository> _repositoryMock;
        private readonly Mock<ILogger<LanguageFallbackService>> _loggerMock;
        private readonly LanguageFallbackService _service;
        public LanguageFallbackServiceDeleteTests()
        {
            _repositoryMock = new Mock<ILanguageFallbackRepository>();
            _loggerMock = new Mock<ILogger<LanguageFallbackService>>();
            _service = new LanguageFallbackService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<LanguageFallbackDto>("tr");
            var fakeGetResponse = new RepoResponse<LanguageFallbackDto>(fakeDto, "Success");
            var fakeDeleteResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<LanguageFallbackDto>())).ReturnsAsync(fakeDeleteResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<LanguageFallbackDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteItemAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            var fakeDto = TestDataGenerator.CreateFake<LanguageFallbackDto>("tr");
            // Arrange
            var fakeGetResponse = new RepoResponse<LanguageFallbackDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.DeleteItemAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.LanguageId, fakeDto.FallbackLanguageId), Times.Once);
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<LanguageFallbackDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}