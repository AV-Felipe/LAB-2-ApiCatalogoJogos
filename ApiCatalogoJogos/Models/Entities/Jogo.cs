using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Models.Entities
{
    //as classes da camada entity, representam os objetos do nosso banco. As views models, que são DTOs, podem ser composições
    //de multiplas entidades ou mesmo partes de uma
    public class Jogo
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string produtora { get; set; }
        public string plataforma { get; set; }
        public string genero { get; set; }
        public double preco { get; set; }
    }
}
