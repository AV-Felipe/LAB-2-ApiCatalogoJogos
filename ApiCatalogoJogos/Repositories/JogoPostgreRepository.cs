using ApiCatalogoJogos.Models.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoPostgreRepository : IJogoRepository
    {
        private readonly NpgsqlConnection sqlConnection;

        public JogoPostgreRepository(IConfiguration configuration)
        {
            sqlConnection = new NpgsqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();

            var comando = $"select * from tabelajogos order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            NpgsqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)sqlDataReader["id"],
                    name = (string)sqlDataReader["name"],
                    produtora = (string)sqlDataReader["produtora"],
                    plataforma = (string)sqlDataReader["plataforma"],
                    genero = (string)sqlDataReader["genero"],
                    preco = (double)sqlDataReader["preco"]
                });
            }

            await sqlConnection.CloseAsync();

            return jogos;
        }

        public async Task<Jogo> Obter(Guid id)
        {
            Jogo jogo = null;

            var comando = $"select * from tabelajogos where id = '{id}'";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            NpgsqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogo = new Jogo
                {
                    Id = (Guid)sqlDataReader["id"],
                    name = (string)sqlDataReader["name"],
                    produtora = (string)sqlDataReader["produtora"],
                    plataforma = (string)sqlDataReader["plataforma"],
                    genero = (string)sqlDataReader["genero"],
                    preco = (double)sqlDataReader["preco"]
                };
            }

            await sqlConnection.CloseAsync();

            return jogo;
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            var jogos = new List<Jogo>();

            var comando = $"select * from tabelajogos where name = '{nome}' and produtora = '{produtora}'";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            NpgsqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)sqlDataReader["id"],
                    name = (string)sqlDataReader["name"],
                    produtora = (string)sqlDataReader["produtora"],
                    plataforma = (string)sqlDataReader["plataforma"],
                    genero = (string)sqlDataReader["genero"],
                    preco = (double)sqlDataReader["preco"]
                });
            }

            await sqlConnection.CloseAsync();

            return jogos;
        }

        public async Task Inserir(Jogo jogo)
        {
            var comando = $"insert into tabelajogos (id, name, produtora, plataforma, genero, preco) values ('{jogo.Id}', '{jogo.name}', '{jogo.produtora}', '{jogo.plataforma}','{jogo.genero}', {jogo.preco.ToString().Replace(",", ".")})";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Jogo jogo)
        {
            var comando = $"update tabelajogos set name = '{jogo.name}', produtora = '{jogo.produtora}',plataforma = '{jogo.plataforma}', genero = '{jogo.genero}', preco = {jogo.preco.ToString().Replace(",", ".")} where Id = '{jogo.Id}'";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete from tabelajogos where id = '{id}'";

            await sqlConnection.OpenAsync();
            NpgsqlCommand sqlCommand = new NpgsqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
