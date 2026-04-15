using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.ContentManagementModule.Application.Tests.Services.ContentTag
{
    public class UpdateContentTagCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IContentTagRepository> _repositoryMock;
        private readonly Mock<ILogger<ContentTagService>> _loggerMock;
        private readonly ContentTagService _service;
        public UpdateContentTagCommandTests()
        {
            _repositoryMock = new Mock<IContentTagRepository>();
            _loggerMock = new Mock<ILogger<ContentTagService>>();
            _service = new ContentTagService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Success_When_Item_Exists()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            var fakeGetResponse = new RepoResponse<ContentTagDto>(fakeDto, "Success");
            var fakeUpdateResponse = new RepoResponse<bool>(true, "Success");
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId)).ReturnsAsync(fakeGetResponse);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<ContentTagDto>())).ReturnsAsync(fakeUpdateResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.True(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<ContentTagDto>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_Item_Does_Not_Exist()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            var fakeGetResponse = new RepoResponse<ContentTagDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.GetByPkAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId)).ReturnsAsync(fakeGetResponse);
            // Act
            var result = await _service.UpdateAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId, fakeDto);
            // Assert
            Assert.Equal(ResultCodeNotFound, result.Code);
            Assert.False(result.Value);
            _repositoryMock.Verify(r => r.GetByPkAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId), Times.Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<ContentTagDto>()), Times.Never);
        }

        public void Dispose()
        {
        // Cleanup handled by xUnit
        }
    }
}