using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardapp.WebApp.Models
{

    [Table("T_CPP_ESTABELECIMENTO")]
    public class Estabelecimento
    {
        [Key]
        [Column("CD_ESTABELECIMENTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoEstabelecimento { get; set; }

        [Column("NM_RAZAO_SOCIAL")]
        [Display(Name = "Qual a razão social do seu estabelecimento?")]
        public string RazaoSocial { get; set; }

        [Column("NM_FANTASIA")]
        [Display(Name = "Qual o nome fantasia do seu estabelecimento?")]
        public string NomeFantasia { get; set; }

        [Column("DS_CNPJ")]
        [Display(Name = "Cnpj do estabelecimento")]
        public string Cnpj { get; set; }

        [Column("DS_ENDERECO")]
        [Display(Name = "Qual o endereço do seu estabelecimento?")]
        public string Endereco { get; set; }

        [Column("NR_TELEFONE")]
        [Display(Name = "Qual o telefone do seu estabelecimento?")]
        public string Telefone { get; set; }

        [Column("DS_EMAIL")]
        [Display(Name = "Qual o email do seu estabelecimento?")]
        public string Email { get; set; }


    }
}
