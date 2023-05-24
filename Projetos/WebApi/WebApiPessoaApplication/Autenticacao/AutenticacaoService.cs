using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApiPessoa.Repository;
using WebApiPessoa.Repository.Models;

namespace WebApiPessoaApplication.Autenticacao
{
    public class AutenticacaoService 
    {
        private readonly PessoaContext _context;
        public AutenticacaoService(PessoaContext context)
        {
            _context = context;
        }

        public AutenticacaoResponse Autenticar(AutenticacaoRequest request)
         {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.usuario == request.UserName && x.senha == request.Password);
            if (usuario != null  )
            {
                var tokenString = GerarTokenJwt(usuario);

                var resposta = new AutenticacaoResponse()
                {
                    Token = tokenString,
                    UsuarioId = usuario.id
                };

                return resposta;
            }

            else
            {
                return null;
            }
        }
         private string GerarTokenJwt(TabUsuario usuario)
        {
            var issuer = "var";
            var audience = "var";
            var key = "6829509f-7d87-4ed9-9900-14627fd85cb7";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("usuarioId", usuario.id.ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
