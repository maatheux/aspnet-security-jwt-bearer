using System.IdentityModel.Tokens.Jwt;
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
        new SigningCredentials(
            new SymmetricSecurityKey(key), /* Metodo da chave simetrica onde passamos a chave */ 
            SecurityAlgorithms.HmacSha256);
        
        var token = handler.CreateToken();
        return handler.WriteToken(token);
    }
}