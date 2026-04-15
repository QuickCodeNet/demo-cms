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
    public class InsertLanguageFallbackCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ILanguageFallbackRepository> _repositoryMock;
        private readonly Mock<ILogger<LanguageFallbackService>> _loggerMock;
        private readonly LanguageFallbackService _service;
        public InsertLanguageFallbackCommandTests()
        {
            _repositoryMock = new Mock<ILanguageFallbackRepository>();
            _loggerMock = new Mock<ILogger<LanguageFallbackService>>();
            _service = new LanguageFallbackService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<LanguageFallbackDto>("tr");
            var fakeResponse = new RepoResponse<LanguageFallbackDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<LanguageFallbackDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<LanguageFallbackDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<LanguageFallbackDto>("tr");
            var fakeResponse = new RepoResponse<LanguageFallbackDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<LanguageFallbackDto>())).ReturnsAsync(fakeResponse);
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