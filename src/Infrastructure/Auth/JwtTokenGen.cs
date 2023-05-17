using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Domain.User.Entities;

namespace Infrastructure.Auth;

public class JwtTokenGen : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGen(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
    }
    public string GenerateToken(User user)
    {   
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("123456789000000_super-secret-key")),
            SecurityAlgorithms.HmacSha256Signature);

        var claims = new []{
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddHours(_jwtSettings.Expiry),
            claims: claims,
            signingCredentials: signingCredentials
            ); 

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}