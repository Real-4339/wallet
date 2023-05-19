using Application.Users.Queries.Balance;
using Application.Common.Results;
using Dtos.User.Balance;
using Dtos.User;
using Mapster;

namespace Api.Mapping;

public class WalletConf : IRegister
{
    public void Register(TypeAdapterConfig config)
    {   
        config.NewConfig<StatusResult, RegisterWalletResponse>()
            .Map(dest => dest, src => src);

        config.NewConfig<GetBalanceResult, GetBalanceResponse>()
            .Map(dest => dest, src => src);
    }
}
