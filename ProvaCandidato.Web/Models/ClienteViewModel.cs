using System;
using System.ComponentModel.DataAnnotations;

namespace ProvaCandidato.Models
{
    public class ClienteViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Mínimo 3 caracteres")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Máximo 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "O formato da data é inválido")]
        public DateTime? DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public int CidadeId { get; set; }

        public CidadeViewModel Cidade { get; set; }
    }
}