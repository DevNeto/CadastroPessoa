using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiPessoa.Repository;
using WebApiPessoaApplication.Usuario;

namespace WebApiPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly PessoaContext _context;

            public UsuarioController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult InserirUsuario([FromBody] UsuarioRequest request)
        {
            var usuarioService = new UsuarioServive(_context);
            var sucesso = usuarioService.InserirUsuario(request);

            if (sucesso == true)
            {
                return NoContent();
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]

        public IActionResult ObterUsuarios()
        {
            var usuarioService = new UsuarioServive(_context);
            var usuarios = usuarioService.ObterUsuarios();

            if (usuarios == null)
            {
               return BadRequest();
            }
            else
            {
                return Ok(usuarios);
            }
            
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult ObterUsuario([FromRoute] int id)
        {
            var usuarioService = new UsuarioServive(_context);
            var usuario = usuarioService.ObterUsuario(id);
            if (usuario == null)
            {
                return BadRequest();
            } else
            {
                return Ok(usuario);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] UsuarioRequest request)
        {
            var usuarioService = new UsuarioServive(_context);
            var sucesso = usuarioService.AtualizarUsuario(id, request);

            if (sucesso == true)
            {
                return NoContent();
            } 
              else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]

        public IActionResult RemoverUsuario([FromRoute] int id)
        {
            var usuarioService = new UsuarioServive(_context);
            var sucesso = usuarioService.RemoverUsuario(id);

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
