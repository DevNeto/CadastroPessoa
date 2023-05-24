using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApiPessoa.Repository;
using WebApiPessoaApplication.Autenticacao;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase 
    {
        private readonly PessoaContext _context;
        public AutenticacaoController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request)
        {
            var autenticacaoService = new AutenticacaoService(_context );
            var resposta = autenticacaoService.Autenticar(request);

            if (resposta == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resposta);
            } 
        }
    }
}
