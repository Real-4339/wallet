using Application.Auth.Results;
using Dtos.Authentication;
using Mapster;

namespace Api.Mapping;

public class RegMappConf : IRegister
{
    public void Register(TypeAdapterConfig config)
    {   
        config.NewConfig<AuthRegResult, RegisterResponse>()
            .Map(dest => dest, src => src.User);
    }
}

