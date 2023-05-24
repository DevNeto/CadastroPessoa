using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiPessoa.Repository;
using WebApiPessoaApplication.Pessoa;
using WebApiPessoaApplication.Usuario;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly PessoaContext _context;
        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Rota responsavel por realizar o processamento de pessoa - Calcula idade, calcula imc, calcula inss, realiza conversão de saldo para dolar
        /// </summary>
        /// <returns>Retorna os dados processados da pessoa</returns>
        /// <response code="200">Retorna os dados processados com sucesso</response>
        [HttpPost]
        [Authorize]
        public PessoaResponse ProcessarInformacoesPessoa([FromBody] PessoaRequest request)
        { 
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var usuarioId = identidade.FindFirst("usuarioId").Value;  

            var pessoaService = new PessoaService(_context);
            var pesooaResponse = pessoaService.ProcessarInformacoesPessoa(request, Convert.ToInt32(usuarioId));

            return pesooaResponse;
        }

        [HttpGet]
        [Authorize]
    public  List<PessoaHistoricoResponse> ObterHistoricoPessoas()
        {
            var pessoaService = new PessoaService(_context);
            var pessoas = pessoaService.ObterHistoricoPessoas();

            return pessoas;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public PessoaHistoricoResponse ObterHistoricoPessoa([FromRoute] int id)
        {
            var pessoaService = new PessoaService(_context);
            var pessoa = pessoaService.ObterHistoricoPessoa(id);

            return pessoa;
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]

        public IActionResult RemoverPessoa([FromRoute] int id)
        {
            var pessoaService = new PessoaService(_context);
            var sucesso = pessoaService.RemoverPessoa(id);

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
