using Facturama.Sdk.Configuration;
using Facturama.Sdk.Core.Enums;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Tests.Unit.Configuration
{
    public class FacturamaOptionsTests
    {
        [Fact]
        public void Validate_WithValidOptions_ShouldNotThrow()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Username = "test-user",
                Password = "test-password",
                Environment = FacturamaEnvironment.Sandbox,
            };

            // Act
            Action act = () => options.Validate();

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Validate_WithEmptyUsername_ShouldThrow()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Username = "",
                Password = "test-password"
            };

            // Act
            Action act = () => options.Validate();

            // Assert
            act.Should().Throw<ValidationException>()
                .WithMessage("*Username*");
        }

        [Fact]
        public void Validate_WithEmptyPassword_ShouldThrow()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Username = "test-user",
                Password = ""
            };

            // Act
            Action act = () => options.Validate();

            // Assert
            act.Should().Throw<ValidationException>()
                .WithMessage("*Password*");
        }

        [Fact]
        public void Validate_WithNegativeTimeout_ShouldThrow()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Username = "test-user",
                Password = "test-password",
                HttpClient = new HttpClientConfiguration
                {
                    Timeout = TimeSpan.FromSeconds(-1)
                }
            };

            // Act
            Action act = () => options.Validate();

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("*Timeout*mayor a cero*");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void Validate_WithInvalidMaxRetries_ShouldThrow(int maxRetries)
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Username = "test-user",
                Password = "test-password",
                RetryPolicy = new RetryPolicyConfiguration
                {
                    MaxRetries = maxRetries
                }
            };

            // Act
            Action act = () => options.Validate();

            // Assert
            act.Should().Throw<ValidationException>()
                .WithMessage("*MaxRetries*");
        }

        [Fact]
        public void BaseUrl_WithSandboxEnvironment_ShouldReturnSandboxUrl()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Environment = FacturamaEnvironment.Sandbox
            };

            // Act
            var baseUrl = options.BaseUrl;

            // Assert
            baseUrl.Should().Be("https://apisandbox.facturama.mx");
        }

        [Fact]
        public void BaseUrl_WithProductionEnvironment_ShouldReturnProductionUrl()
        {
            // Arrange
            var options = new FacturamaOptions
            {
                Environment = FacturamaEnvironment.Production
            };

            // Act
            var baseUrl = options.BaseUrl;

            // Assert
            baseUrl.Should().Be("https://api.facturama.mx");
        }
    }
}
