using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        [HttpGet] //routting attribute, neste caso indica que temos um método get - ver: https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        public async Task<ActionResult<List<object>>> Obter() //Aqui temos um método assincrono, "Task" é um tipo de objeto que mantém tarefas em andamento, neste caso, o retorno de nosso método será dado quando tivermos o action result com uma listagem de objetos, a execução, por sua vez, estará livre para outras operações, mesmo antes de termos esse retorno - podemos ter muitas outras tasks rodando - ver: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
        {
            return Ok();
        }

        [HttpGet("{idJogo:guid}")] //passa o valor de idJogo, do método abaixo, para a rota do atributo
        public async Task<ActionResult<object>> Obter(Guid idJogo)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo) //precisamos passar o objeto jogo, que ainda não definimos
        {
            return Ok();
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, object jogo) //o nosso task, aqui, só retornará um action result indicando sucesso ou falha
        {
            return Ok();
        }

        //o httpPatch é similar ao put, mas nos permite atualizar apenas um campo do objeto, neste caso o preço
        [HttpPatch("{idJogo:guid}/preco/{preco:double")]
        public async Task<ActionResult> AtualizarJogo(Guid idJogo, double preco) 
        {
            return Ok();
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idJogo, object jogo)
        {
            return Ok();
        }
    }
}
