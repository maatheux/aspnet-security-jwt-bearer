﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet.Services;

public class TokenService
{
    public string Create()
    {
        var handler = new JwtSecurityTokenHandler(); // gerar o token

        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey); // ASCII - sem carcter especial
        
        // Assinando o token
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        }; // info do token
        
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
}