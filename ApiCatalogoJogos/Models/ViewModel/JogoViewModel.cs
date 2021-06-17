using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Models.ViewModel
{
    //DTO (the data shape of an object without any behavior) do que é exibido ao se pesquisar por um jogo
    public class JogoViewModel
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string produtora { get; set; }
        public string plataforma { get; set; }
        public string genero { get; set; }
        public double preco { get; set; }
    }
}
