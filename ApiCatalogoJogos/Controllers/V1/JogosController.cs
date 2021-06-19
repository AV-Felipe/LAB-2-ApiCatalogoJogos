using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.ViewModel;
using ApiCatalogoJogos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        
        /*
         * Nossos serviços (JogoService.cs) consistem em uma CLASSE, dessa forma, para pormos utilizá-los, precisamos criar uma instância da classe.
         * 
         * Não tenho claro o porquê de instanciar a classe JogoService passando-se a Interface, mas para isso 
         * 
         * precisamos passar para o container do ASP.NET que instância deve ser dada para o caso do objeto IJogoService sendo passado para o construtor
         * Isso é configurado no Startup.cs no método ConfigureServices
         */ 
        private readonly IJogoService _jogoService; 
                
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }




        [HttpGet] //routting attribute, neste caso indica que temos um método get - ver: https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5) //aqui utilizamos data annotations nos parâmetros, fromQuery, nos diz que o parâmetro virá de uma requisição (api?123), assim, ambos os parâmetros que precisamos passar para o método obter, virão da requisição, sendo limitados pelos valores passados pelo Range (podemos ter até o máximo de inteiros para o número de páginas e, para cada página, 50 entradas)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade); //aqui é onde, efetivamente, o serviço é evocado, recebendo os valores passados pela url para as variáveis "pagina"e "quantidade" e gerando uma lista de objetos DTO do tipo JogoViewModel

            if (jogos.Count() == 0) //se essa lista de objetos do tipo JogoViewModel for vazia
                return NoContent(); //retorna o código 204 (no content)

            return Ok(jogos); //se existirem elementos na lista, retorna a lista
        }

        [HttpGet("{idJogo:guid}")] //passa o valor de idJogo, do método abaixo, para a rota do atributo
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo) //fromRoute obtem o valor diretamente da url (api/123)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel) //FromBody indica que o valor virá do corpo da requisição, via json, e será transformado, pelo pipeline do asp.net no nosso modelo de DTO (JogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        //o httpPatch é similar ao put, mas nos permite atualizar apenas um campo do objeto, neste caso o preço
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }
    }
}
