using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Cfdi;
using Facturama.Sdk.Tests.Unit.Helpers;
using FacturamaAPI.src.Facturama.Sdk.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Tests.Unit.Services
{
    public class CfdiServiceTests
    {
        private readonly Mock<IApiWebHttpClient> _httpClientMock;
        private readonly ILogger<CfdiService> _logger;
        private readonly CfdiService _sut; // System Under Test



        public CfdiServiceTests()
        {
            _httpClientMock = new Mock<IApiWebHttpClient>();
            _logger = TestHelpers.CreateLogger<CfdiService>();
            _sut = new CfdiService(_httpClientMock.Object, _logger);
        }


        [Fact]
        public async Task CreateAsync_WithValidRequest_ShouldReturnCfdiResponse()
        {
            // Arrange
            var request = new CfdiRequest
            {
                Receiver = new Receiver
                {
                    Rfc = "XAXX010101000",
                    Name = "Test Client",
                    CfdiUse = "G03"
                }
            };

            var expectedResponse = new CfdiResponse
            {
                Id = "test-id",
                Folio = "123",
                Complement = new Complement
                {
                    TaxStamp = new TaxStamp
                    {
                        Uuid = "12345678-1234-1234-1234-123456789012"
                    }
                }
            };

            _httpClientMock
                .Setup(x => x.PostAsync<CfdiResponse>(
                    It.Is<string>(s => s.Contains("cfdis")),
                    It.IsAny<object>(),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _sut.CreateAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("test-id");
            result.Folio.Should().Be("123");
            result.Complement.Should().NotBeNull();
            result.Complement!.TaxStamp!.Uuid.Should().Be("12345678-1234-1234-1234-123456789012");

            _httpClientMock.Verify(
                x => x.PostAsync<CfdiResponse>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task CreateAsync_WithNullRequest_ShouldThrowArgumentNullException()
        {
            // Arrange
            CfdiRequest? request = null;

            // Act
            Func<Task> act = async () => await _sut.CreateAsync(request!);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>()
                .WithParameterName("request");
        }

        [Fact]
        public async Task GetAsync_WithValidId_ShouldReturnCfdi()
        {
            // Arrange
            var cfdiId = "test-cfdi-id";
            var expectedResponse = new CfdiResponse
            {
                Id = cfdiId,
                Folio = "123"
            };

            _httpClientMock
                .Setup(x => x.GetAsync<CfdiResponse>(
                    It.Is<string>(s => s.Contains(cfdiId)),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _sut.GetAsync(cfdiId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(cfdiId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task GetAsync_WithInvalidId_ShouldThrowArgumentException(string? cfdiId)
        {
            // Act
            Func<Task> act = async () => await _sut.GetAsync(cfdiId!);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetAsync_WhenNotFound_ShouldThrowFacturamaNotFoundException()
        {
            // Arrange
            var cfdiId = "non-existent-id";

            _httpClientMock
                .Setup(x => x.GetAsync<CfdiResponse>(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new FacturamaNotFoundException("Not found", "{}"));

            // Act
            Func<Task> act = async () => await _sut.GetAsync(cfdiId);

            // Assert
            await act.Should().ThrowAsync<FacturamaNotFoundException>();
        }

        [Fact]
        public async Task CancelAsync_WithValidParameters_ShouldSucceed()
        {
            // Arrange
            var cfdiId = "test-id";
            var cfdiType = "issued";
            var motive = "02";

            var expectedResponse = new CfdiCancellationResponse
            {
                Status = "Cancelled"
            };

            _httpClientMock
                .Setup(x => x.DeleteAndResponseAsync<CfdiCancellationResponse>(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _sut.CancelAsync(cfdiId, cfdiType, motive);

            // Assert
            result.Should().NotBeNull();
            result.Status.Should().Be("Cancelled");
        }

        [Fact]
        public async Task ListAsync_WithFilter_ShouldReturnList()
        {
            // Arrange
            var expectedList = new List<ListCfdiResponse>
        {
            new ListCfdiResponse { Id = "1" },
            new ListCfdiResponse { Id = "2" }
        };

            _httpClientMock
                .Setup(x => x.GetAsync<List<ListCfdiResponse>>(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string?>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedList);

            // Act
            var result = await _sut.ListAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeAssignableTo<IReadOnlyList<ListCfdiResponse>>();
        }
    }
}
