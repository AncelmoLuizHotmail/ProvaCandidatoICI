using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaCandidato.Models
{
    public class CidadeViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Mínimo 3 caracteres")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Máximo 50 caracteres")]
        public string Nome { get; set; }
    }
}