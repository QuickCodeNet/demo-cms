using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.LocalizationModule.Application.Services.TranslationValue;
using QuickCode.DemoCms.LocalizationModule.Application.Dtos.TranslationValue;
using QuickCode.DemoCms.LocalizationModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.LocalizationModule.Application.Tests.Services.TranslationValue
{
    public class UpdateTranslationValueCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<ITranslationValueRepository> _repositoryMock;
        private readonly Mock<ILogger<TranslationValueService>> _loggerMock;
        private readonly TranslationValueService _service;
        public UpdateTranslationValueCommandTests()
        {
            _repositoryMock = new Mock<ITranslationValueRepository>();
            _loggerMock = new Mock<ILogger<TranslationValueService>>();
            _service = new TranslationValueService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TranslationValueDto>("tr");
            var fakeGetResponse = new RepoResponse<TranslationValueDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<TranslationValueDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TranslationValueDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<TranslationValueDto>("tr");
            var fakeGetResponse = new RepoResponse<TranslationValueDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.Id)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.Id, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.Id), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<TranslationValueDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}