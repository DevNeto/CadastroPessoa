  using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OlaMundo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlaMundoController : ControllerBase
    {  

        public OlaMundoController(ILogger<OlaMundoController> logger)
        {

        }

        [HttpGet]

        //visibilidade / nivel de acesso
        //public - publico / private - privado....
        //retorna = IEnumerable = lista
        public OlaMundo ObterMensagem()
        {
         
            var retorno = new OlaMundo();
            retorno.Mensagem = "Olá Mundo!!, esse é o meu primeiro Web API em C# ";
            return retorno;
    }
    

        }
    }

