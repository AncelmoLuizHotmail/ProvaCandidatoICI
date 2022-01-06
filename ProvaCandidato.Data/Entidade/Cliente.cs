using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; private set; }

        [StringLength(50)]
        [Required]
        [Column("nome")]
        public string Nome { get; private set; }

        [Column("data_nascimento")]
        public DateTime? DataNascimento { get; private set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; private set; }

        public bool Ativo { get; private set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; private set; }
    }
}