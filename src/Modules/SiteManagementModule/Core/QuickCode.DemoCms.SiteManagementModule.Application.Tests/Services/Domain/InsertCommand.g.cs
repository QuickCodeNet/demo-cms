using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using QuickCode.DemoCms.SiteManagementModule.Application.Services.Domain;
using QuickCode.DemoCms.SiteManagementModule.Application.Dtos.Domain;
using QuickCode.DemoCms.SiteManagementModule.Application.Interfaces.Repositories;
using QuickCode.DemoCms.Common.Helpers;
using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.SiteManagementModule.Application.Tests.Services.Domain
{
    public class InsertDomainCommandTests : IDisposable
    {
        private const int ResultCodeSuccess = 0;
        private const int ResultCodeNotFound = 404;
        private readonly Mock<IDomainRepository> _repositoryMock;
        private readonly Mock<ILogger<DomainService>> _loggerMock;
        private readonly DomainService _service;
        public InsertDomainCommandTests()
        {
            _repositoryMock = new Mock<IDomainRepository>();
            _loggerMock = new Mock<ILogger<DomainService>>();
            _service = new DomainService(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_Success_When_Valid_Request()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DomainDto>("tr");
            var fakeResponse = new RepoResponse<DomainDto>(fakeDto, "Success");
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DomainDto>())).ReturnsAsync(fakeResponse);
            // Act
            var result = await _service.InsertAsync(fakeDto);
            // Assert
            Assert.Equal(ResultCodeSuccess, result.Code);
            Assert.Equal(fakeDto, result.Value);
            _repositoryMock.Verify(r => r.InsertAsync(It.IsAny<DomainDto>()), Times.Once);
        }

        [Fact]
        public async Task InsertAsync_Should_Return_NotFound_When_Repository_Returns_404()
        {
            // Arrange
            var fakeDto = TestDataGenerator.CreateFake<DomainDto>("tr");
            var fakeResponse = new RepoResponse<DomainDto>
            {
                Code = ResultCodeNotFound,
                Message = "Not found"
            };
            _repositoryMock.Setup(r => r.InsertAsync(It.IsAny<DomainDto>())).ReturnsAsync(fakeResponse);
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