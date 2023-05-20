using Api.Controllers;
using Dtos.Authentication;
using Domain.UserAggregate;
using Application.Auth.Results;
using Application.Common.Results;
using Application.Auth.Queries.Login;
using Application.Auth.Commands.Register;

namespace AllTests;

public class AuthControllerTests
{   
    private readonly Mock<ISender> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly AuthController _authController;


    public AuthControllerTests()
    {
        _mediatorMock = new Mock<ISender>();
        _mapperMock = new Mock<IMapper>();
        _authController = new AuthController(
            _mediatorMock.Object, 
            _mapperMock.Object);
    }

    [Fact]
    public async Task Register_ShouldReturnOkResult()
    {
        // Arrange
        var registerRequest = new RegisterRequest(
            FirstName: "John",
            LastName: "Doe",
            Email: "john.doe@example.com",
            Username: "johndoe",
            Password: "password123"
        );

        var registerCommand = new RegisterCommand(
            FirstName: "",
            LastName: "",
            Email: "",
            Username: "",
            Password: ""
        );
        var authRegResult = new AuthRegResult(
            User: _mapperMock.Object.Map<User>(registerCommand),
            Token: ""
        );
        var registerResponse = new RegisterResponse(
            Id: Guid.NewGuid(),
            Username: "",
            Token: ""
        );

        _mapperMock.Setup(m => m.Map<RegisterCommand>(registerRequest)).Returns(registerCommand);
        _mediatorMock.Setup(m => m.Send(registerCommand, default)).ReturnsAsync(authRegResult);
        _mapperMock.Setup(m => m.Map<RegisterResponse>(authRegResult)).Returns(registerResponse);

        // Act
        var result = await _authController.Register(registerRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RegisterResponse>(okResult.Value);
        Assert.Equal(registerResponse, returnValue);
    }

    [Fact]
    public async Task Login_ShouldReturnOkResult()
    {
        // Arrange
        var loginRequest = new LoginRequest(
            Username: "",
            Password: ""
        );  
        var loginQuery = new LoginQuery(
            Username: "",
            Password: ""
        );
        var statusResult = new StatusResult(
            Status: ""
        );
        var loginResponse = new LoginResponse(
            Status: ""
        );

        _mapperMock.Setup(m => m.Map<LoginQuery>(loginRequest)).Returns(loginQuery);
        _mediatorMock.Setup(m => m.Send(loginQuery, default)).ReturnsAsync(statusResult);
        _mapperMock.Setup(m => m.Map<LoginResponse>(statusResult)).Returns(loginResponse);

        // Act
        var result = await _authController.Login(loginRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<LoginResponse>(okResult.Value);
        Assert.Equal(loginResponse, returnValue);
    }

}