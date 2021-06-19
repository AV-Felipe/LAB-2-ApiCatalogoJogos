using ApiCatalogoJogos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        //Repositório mockado
        //Criamos um dicionário, para termos uma base de dados de teste constante
        //nos demais métodos, não estamos utilizando o parâmetro async e, nos statements, estamos utilizando Task.FromResult, para passarmos os retornos no formato esperado (tasks) - por isso não utilizamos o await
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Jogo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), name = "Fifa 21", produtora = "EA", plataforma = "Play-Station", genero = "esportes", preco = 200} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Jogo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), name = "Fifa 20", produtora = "EA", plataforma = "Play-Station", genero = "esportes", preco = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Jogo{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), name = "Fifa 19", produtora = "EA", plataforma = "Play-Station", genero = "esportes", preco = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Jogo{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), name = "Fifa 18", produtora = "EA", plataforma = "Play-Station", genero = "esportes", preco = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Jogo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), name = "Street Fighter V", produtora = "Capcom", plataforma = "Play-Station", genero = "luta", preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Jogo{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), name = "Grand Theft Auto V", produtora = "Rockstar", plataforma = "Play-Station", genero = "mete-o-louco", preco = 190} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult<Jogo>(null);

            return Task.FromResult(jogos[id]);
        }

        //duas formas de se obter uma listagem, uma por meio da biblioteca do LINQ - ver: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/working-with-linq
        //outra por meio de uma iteração (foreach) e um condicional (if) aninhado
        public Task<List<Jogo>> Obter(string nome, string produtora) //LINQ
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.name.Equals(nome) && jogo.produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora) //Iteração+condicional
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.name.Equals(nome) && jogo.produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco - não temos banco neste repositório mockado
        }
    }
}
