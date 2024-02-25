using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Naft.Domain.Entities;

namespace Naft.Infra.Services;

public class TokenService
{
 public string GenerateToken(User user)
 {
     var tokenHandler = new JwtSecurityTokenHandler();
     var key = Encoding.ASCII.GetBytes(Settings.JwtKey);
     var tokenDescriptor = new SecurityTokenDescriptor();
     var token = tokenHandler.CreateToken(tokenDescriptor);
     return tokenHandler.WriteToken(token);
}