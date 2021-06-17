using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Models.InputModel
{
    //DTO do que se espera que seja passado para a API para se cadastrar um jogo

    //usamos regras do data annotations para já detectar erros no input do usuário no midware, antes de o controller manipular os dados (Fail Fast Validation)
    public class JogoInputModel
    {
        [Required]
        [StringLength(50, MinimumLength =1, ErrorMessage = "O nome do jogo é obrigatório e deve conter, no mínmo, 1 e, no máximo, 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome da produtora é obrigatório e deve conter, no mínmo, 1 e, no máximo, 50 caracteres")]
        public string produtora { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome da plataforma é obrigatório e deve conter, no mínmo, 1 e, no máximo, 50 caracteres")]
        public string plataforma { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O gênero do jogo é obrigatório e deve conter, no mínmo, 1 e, no máximo, 50 caracteres")]
        public string genero { get; set; }

        [Required]
        [Range(0.01, 999999, ErrorMessage = "O nome valor do jogo é obrigatório, não podendo ser menos do que R$0,01 nem mais do que R$999.999,99")]
        public double preco { get; set; }
    }
}
