using Estudo.MinhaApi.Api.HATEOAS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudo.MinhaApi.Api.DTOs
{
    public class AlunoDTO : RestResource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório!")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "O nome deve conter no mínimo 2 caracteres e no máximo 20!")]
        public string Nome { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "O endereço deve conter no máximo 100 caracteres!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A mensalidade é obrigatória!")]
        [Range(minimum: 0.1, maximum: 999.99, ErrorMessage = "A mensalidade deve estar entre R$0,01 e R$999,99!" )]
        public decimal Mensalidade { get; set; }
    }
}