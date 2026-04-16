using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.ContentManagementModule.Api.Controllers;
using QuickCode.DemoCms.ContentManagementModule.Application.Dtos.ContentTag;
using QuickCode.DemoCms.ContentManagementModule.Application.Services.ContentTag;
using System.Collections.Generic;
using QuickCode.DemoCms.Common.Models;
using QuickCode.DemoCms.Common.Helpers;
using ContentStatus = QuickCode.DemoCms.ContentManagementModule.Domain.Enums.ContentStatus;
using ContentKind = QuickCode.DemoCms.ContentManagementModule.Domain.Enums.ContentKind;

namespace QuickCode.DemoCms.ContentManagementModule.Api.Tests
{
    public class ContentTagsControllerTests
    {
        private readonly Mock<IContentTagService> _serviceMock = new();
        private readonly Mock<ILogger<ContentTagsController>> _loggerMock = new();
        private readonly ContentTagsController _controller;
        public ContentTagsControllerTests()
        {
            _controller = new ContentTagsController(_serviceMock.Object, null, _loggerMock.Object);
        }

        [Fact]
        public async Task ListAsync_Should_Return_Ok_When_Success()
        {
            // Arrange
            var fakeList = TestDataGenerator.CreateFakes<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.ListAsync(It.IsAny<int?>(), It.IsAny<int?>())).ReturnsAsync(new Response<List<ContentTagDto>> { Code = 0, Value = fakeList });
            // Act
            var result = await _controller.ListAsync(1, 10);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(fakeList, okResult.Value);
        }

        [Fact]
        public async Task ListAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            _serviceMock.Setup(s => s.ListAsync(It.IsAny<int?>(), It.IsAny<int?>())).ReturnsAsync(new Response<List<ContentTagDto>> { Code = 1, Message = "Error" });
            // Act
            var result = await _controller.ListAsync(1, 10);
            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Error", badRequest.Value.ToString());
        }

        [Fact]
        public async Task ListAsync_Should_Return_NotFound_When_Page_Less_Than_1()
        {
            // Act
            var result = await _controller.ListAsync(0, 10);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task TotalCountAsync_Should_Return_Ok_When_Success()
        {
            // Arrange
            _serviceMock.Setup(s => s.TotalItemCountAsync()).ReturnsAsync(new Response<int> { Code = 0, Value = 5 });
            // Act
            var result = await _controller.CountAsync();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(5, okResult.Value);
        }

        [Fact]
        public async Task TotalCountAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            _serviceMock.Setup(s => s.TotalItemCountAsync()).ReturnsAsync(new Response<int> { Code = 1, Message = "Error" });
            // Act
            var result = await _controller.CountAsync();
            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Error", badRequest.Value.ToString());
        }

        [Fact]
        public async Task GetItemAsync_Should_Return_Ok_When_Found()
        {
            // Arrange 
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.GetItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<ContentTagDto> { Code = 0, Value = fakeDto });
            // Act
            var result = await _controller.GetItemAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(fakeDto, okResult.Value);
        }

        [Fact]
        public async Task GetItemAsync_Should_Return_NotFound_When_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.GetItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<ContentTagDto> { Code = 404, Message = "Not found" });
            // Act
            var result = await _controller.GetItemAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetItemAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.GetItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<ContentTagDto> { Code = 1, Message = "Error" });
            // Act
            var result = await _controller.GetItemAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Created_When_Success()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.InsertAsync(It.IsAny<ContentTagDto>())).ReturnsAsync(new Response<ContentTagDto> { Code = 0, Value = fakeDto });
            // Act
            var result = await _controller.InsertAsync(fakeDto);
            // Assert
            var created = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal(fakeDto, created.Value);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.InsertAsync(It.IsAny<ContentTagDto>())).ReturnsAsync(new Response<ContentTagDto> { Code = 1, Message = "Insert failed" });
            // Act
            var result = await _controller.InsertAsync(fakeDto);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_Ok_When_Success()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ContentTagDto>())).ReturnsAsync(new Response<bool> { Code = 0, Value = true });
            // Act
            var result = await _controller.UpdateAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId, fakeDto);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_NotFound_When_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ContentTagDto>())).ReturnsAsync(new Response<bool> { Code = 404, Message = "Not found" });
            // Act
            var result = await _controller.UpdateAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId, fakeDto);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.UpdateAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ContentTagDto>())).ReturnsAsync(new Response<bool> { Code = 1, Message = "Update failed" });
            // Act
            var result = await _controller.UpdateAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId, fakeDto);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_Should_Return_Ok_When_Success()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.DeleteItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<bool> { Code = 0, Value = true });
            // Act
            var result = await _controller.DeleteAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task DeleteAsync_Should_Return_NotFound_When_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.DeleteItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<bool> { Code = 404, Message = "Not found" });
            // Act
            var result = await _controller.DeleteAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_Should_Return_BadRequest_When_Fail()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<ContentTagDto>("tr");
            _serviceMock.Setup(s => s.DeleteItemAsync(It.IsAny<ContentKind>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new Response<bool> { Code = 1, Message = "Delete failed" });
            // Act
            var result = await _controller.DeleteAsync(fakeDto.ContentTypeKind, fakeDto.ContentId, fakeDto.TagId);
            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}