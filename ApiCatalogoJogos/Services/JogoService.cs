using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.Models.Entities;
using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.ViewModel;
using ApiCatalogoJogos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        //Implementação dos serviços estipulados na interface IJogoService

        /*
         * Precisamos gerar uma instância da nossa classe JogoRepository. Não ficou claro o porquê de se fazer isso pela interface, mas para tanto
         * precisamos passar para o container do ASP.NET que instância deve ser dada para o caso do objeto IJogoService sendo passado para o construtor
         * Isso é configurado no Startup.cs no método ConfigureServices
         */
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel //select é um método da classe Enumerable, do namespace System.Linq - ver: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=net-5.0
            //aqui fazemos o mapeamento do entity para o DTO
            {
                Id = jogo.Id, //a propriedade Id do DTO JogoViewModel deve receber seu valor da propriedade Id da entidade Jogo
                name = jogo.name,
                produtora = jogo.produtora,
                plataforma = jogo.plataforma,
                genero = jogo.genero,
                preco = jogo.preco
            })
                               .ToList();
        }

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                name = jogo.name,
                produtora = jogo.produtora,
                plataforma = jogo.plataforma,
                genero = jogo.genero,
                preco = jogo.preco
            };
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogo.Nome, jogo.produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                name = jogo.Nome,
                produtora = jogo.produtora,
                plataforma = jogo.plataforma,
                genero = jogo.genero,
                preco = jogo.preco
            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                name = jogo.Nome,
                produtora = jogo.produtora,
                plataforma = jogo.plataforma,
                genero = jogo.genero,
                preco = jogo.preco
            };
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.name = jogo.Nome;
            entidadeJogo.produtora = jogo.produtora;
            entidadeJogo.plataforma = jogo.plataforma;
            entidadeJogo.genero = jogo.genero;
            entidadeJogo.preco = jogo.preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.Remover(id);
        }

        public void Dispose() //elimina as conexões abertas com o banco de dados após a execução
        {
            _jogoRepository?.Dispose();
        }
    }
}
