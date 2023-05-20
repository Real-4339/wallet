using Dtos.User;
using Api.Controllers;
using Dtos.User.Wallet;
using Dtos.User.Balance;
using Dtos.User.Transactions;
using Application.Common.Results;
using Application.Users.Queries.Balance;
using Application.Users.Commands.Wallet;
using Application.Users.Queries.Transactions;


namespace AllTests;

public class UserControllerTests
{
    private readonly Mock<ISender> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UserController _userController;

    public UserControllerTests()
    {
        _mediatorMock = new Mock<ISender>();
        _mapperMock = new Mock<IMapper>();
        _userController = new UserController(_mediatorMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Create_ShouldReturnOkResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new RegisterWalletRequest();
        var command = new RegisterWalletCommand(userId);
        var walletResult = new StatusResult(
            Status: ""
        );
        var response = new RegisterWalletResponse(
            Status: ""
        );

        _mapperMock.Setup(m => m.Map<RegisterWalletCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, default)).ReturnsAsync(walletResult);
        _mapperMock.Setup(m => m.Map<RegisterWalletResponse>(walletResult)).Returns(response);

        // Act
        var result = await _userController.Create(request, userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<RegisterWalletResponse>(okResult.Value);
        Assert.Equal(response, returnValue);
    }

    [Fact]
    public async Task Get_ShouldReturnOkResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new GetBalanceRequest();
        var query = new GetBalanceQuery(userId);
        var balanceResult = new GetBalanceResult(
            UserId: userId,
            Balance: 0
        );
        var response = new GetBalanceResponse(
            UserId: userId,
            Balance: 0
        );

        _mapperMock.Setup(m => m.Map<GetBalanceQuery>(request)).Returns(query);
        _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(balanceResult);
        _mapperMock.Setup(m => m.Map<GetBalanceResponse>(balanceResult)).Returns(response);

        // Act
        var result = await _userController.Get(request, userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<GetBalanceResponse>(okResult.Value);
        Assert.Equal(response, returnValue);
    }

    [Fact]
    public async Task GetTransactions_ShouldReturnForbiddenResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new GetTxRequest(
            TxTypes: "deposit");
        var txTypes = request.TxTypes.Split(',').Select(txType => txType.Trim()).ToList();
        var query = new GetTxQuery(userId, txTypes);
        var txResult = new GetTxResult(
            UserId: userId,
            Transactions: new List<string>()
        );
        var response = new GetTxResponse(
            UserId: userId,
            Transactions: new List<string>()
        );

        _mapperMock.Setup(m => m.Map<GetTxQuery>(request)).Returns(query);
        _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(txResult);
        _mapperMock.Setup(m => m.Map<GetTxResponse>(txResult)).Returns(response);

        // Act
        var result = await _userController.GetTransactions(userId, request);

        // Assert
        var NotokResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<GetTxResponse>(NotokResult.Value);
        Assert.Equal(response, returnValue);
    }
    
}