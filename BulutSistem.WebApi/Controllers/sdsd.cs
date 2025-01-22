
    using BulutSistem.WebApi.Controllers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Extensions.Logging;
    using global::BulutSistem.Appllication.Features.Auth.Login;
    using global::BulutSistem.Appllication.Features.Auth.Register;

    namespace BulutSistem.WebApi.Tests.Controllers
    {
        public class AuthsControllerTests
        {
            private readonly Mock<IMediator> _mediatorMock;
            private readonly Mock<ILogger<AuthsController>> _loggerMock;
            private readonly AuthsController _controller;

            public AuthsControllerTests()
            {
                _mediatorMock = new Mock<IMediator>();
                _loggerMock = new Mock<ILogger<AuthsController>>();
                _controller = new AuthsController(_mediatorMock.Object, _loggerMock.Object);
            }

            #region Login Tests

            [Fact]
            public async Task Login_ShouldReturn200_WhenLoginIsSuccessful()
            {
                // Arrange
                var request = new LoginCommand { UserorEmail = "test@example.com", Password = "password" };
                var response = new { Token = "valid_token" }; // Expected response
                _mediatorMock.Setup(m => m.Send(It.IsAny<LoginCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

                // Act
                var result = await _controller.Login(request, CancellationToken.None);

                // Assert
                var actionResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(200, actionResult.StatusCode);
                Assert.Equal(response, actionResult.Value); // Assert that the response matches the mock
            }

            [Fact]
            public async Task Login_ShouldReturn500_WhenExceptionOccurs()
            {
                // Arrange
                var request = new LoginCommand { UserorEmail = "test@example.com", Password = "password" };
                _mediatorMock.Setup(m => m.Send(It.IsAny<LoginCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Login failed"));

                // Act
                var result = await _controller.Login(request, CancellationToken.None);

                // Assert
                var actionResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(500, actionResult.StatusCode);
                Assert.Equal("Bir hata oluştu.", actionResult.Value); // Assert error message
            }

            #endregion

            #region Register Tests

            [Fact]
            public async Task Register_ShouldReturnNoContent_WhenRegistrationIsSuccessful()
            {
                // Arrange
                var request = new RegisterCommand { UserorEmail = "newuser@example.com", Password = "password" };
                _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

                // Act
                var result = await _controller.Register(request, CancellationToken.None);

                // Assert
                Assert.IsType<NoContentResult>(result);
            }

            [Fact]
            public async Task Register_ShouldReturnBadRequest_WhenExceptionOccurs()
            {
                // Arrange
                var request = new RegisterCommand { UserorEmail = "newuser@example.com", Password = "password" };
                _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Registration failed"));

                // Act
                var result = await _controller.Register(request, CancellationToken.None);

                // Assert
                var actionResult = Assert.IsType<BadRequestResult>(result);
            }

            #endregion

            #region Logger Tests

            [Fact]
            public async Task Login_ShouldLogError_WhenExceptionOccurs()
            {
                // Arrange
                var request = new LoginCommand { UserorEmail = "test@example.com", Password = "password" };
                _mediatorMock.Setup(m => m.Send(It.IsAny<LoginCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Login failed"));

                // Act
                await _controller.Login(request, CancellationToken.None);

                // Assert
                _loggerMock.Verify(logger => logger.LogError(It.IsAny<Exception>(), "Login işlemi sırasında hata oluştu. Kullanıcı adı: {UserorEmail}", request.UserorEmail), Times.Once);
            }

            [Fact]
            public async Task Register_ShouldLogError_WhenExceptionOccurs()
            {
                // Arrange
                var request = new RegisterCommand { UserorEmail = "newuser@example.com", Password = "password" };
                _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Registration failed"));

                // Act
                await _controller.Register(request, CancellationToken.None);

                // Assert
                _loggerMock.Verify(logger => logger.LogError(It.IsAny<Exception>(), "register hata var", request), Times.Once);
            }

            #endregion
        }
    }

}
