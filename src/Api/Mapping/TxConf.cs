using Application.Users.Commands.Transactions;
using Application.Common.Results;
using Dtos.Transactions;
using Mapster;

namespace Api.Mapping;

public class TxConf : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StatusResult, CreditResponse>()
            .Map(dest => dest, src => src);
    }
}