using Microsoft.AspNetCore.Mvc;
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
        [HiddenInput]
        public int CodigoEstabelecimento { get; set; }

        [Column("NM_RAZAO_SOCIAL")]
        [Display(Name = "Qual a razão social do seu estabelecimento?")]
        [Required(ErrorMessage ="teste")]
        public string RazaoSocial { get; set; }

        
        [Required]
        [Column("NM_FANTASIA")]
        [Display(Name = "Qual o nome fantasia do seu estabelecimento?")]
        public string NomeFantasia { get; set; }

        [RegularExpression(@"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/")]
        [Required]
        [Column("DS_CNPJ")]
        [Display(Name = "Cnpj do estabelecimento")]
        public string Cnpj { get; set; }

        [Required]
        [Column("DS_ENDERECO")]
        [Display(Name = "Qual o endereço do seu estabelecimento?")]
        public string Endereco { get; set; }

        [Required]
        [Column("NR_TELEFONE")]
        [Display(Name = "Qual o telefone do seu estabelecimento?")]
        public string Telefone { get; set; }

        [EmailAddress]
        [Required]
        [Column("DS_EMAIL")]
        [Display(Name = "Qual o email do seu estabelecimento?")]
        public string Email { get; set; }

        public string id_Estab_Firebase { get; set; }
    }
}
