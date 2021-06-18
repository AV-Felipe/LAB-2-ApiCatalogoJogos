using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
   /*interface para estabelecer contratos com o controller - independente de como o serviço dos métodos abaixo será montado, já podemos montar
    * toda a controller fazendo uso desses serviços, uma vez que já sabemos quais são os métodos (os aqui assinados) e que parâmetros
    * passar para esses e que retornos esperar deles
   */
   //na interface possuímos apenas a "assinatura" de métodos, prpriedades, eventos e indexadores. A implementação desses se dá por meio de uma classe ou struct
      
    public interface IJogoService
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade); //para a otimização de recursos, prevendo uma lista muito grande, aqui trabalharemos com paginação
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
