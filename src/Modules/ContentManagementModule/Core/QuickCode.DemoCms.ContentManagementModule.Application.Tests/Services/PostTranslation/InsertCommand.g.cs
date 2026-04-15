using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.PostTranslation;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.PostTranslation;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Tests.Services.PostTranslation
{
    public class InsertPostTranslationCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IPostTranslationRepository> _repositoryMock;
        private readonly Mock<ILogger<PostTranslationService>> _loggerMock;
        private readonly PostTranslationService _service;
        public InsertPostTranslationCommandTests()
        {
            _repositoryMock = new Mock<IPostTranslationRepository>();
            _loggerMock = new Mock<ILogger<PostTranslationService>>();
            _service = new PostTranslationService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PostTranslationDto>("tr");
            var fakeResponse = new RepoResponse<PostTranslationDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PostTranslationDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<PostTranslationDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<PostTranslationDto>("tr");
            var fakeResponse = new RepoResponse<PostTranslationDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<PostTranslationDto>())).ReturnsAsync(fakeResponse);
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