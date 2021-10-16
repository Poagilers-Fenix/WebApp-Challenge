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
        public string CodigoEstabelecimento { get; set; }

        [Column("NM_RAZAO_SOCIAL")]
        [Display(Name = "Qual a razão social do seu estabelecimento?")]
        [Required(ErrorMessage ="Este campo é obrigatório.")]
        [MinLength(5, ErrorMessage = "A razão social deve ter 5 caracteres ou mais.")]
        [MaxLength(50, ErrorMessage = "A razão social deve ter menos de 50 caracteres")]
        public string RazaoSocial { get; set; }

        
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("NM_FANTASIA")]
        [Display(Name = "Qual o nome fantasia do seu estabelecimento?")]
        [MinLength(2, ErrorMessage = "O nome fantasia deve ter 2 caracteres ou mais.")]
        [MaxLength(50, ErrorMessage = "O nome fantasia deve ter menos de 50 caracteres")]
        public string NomeFantasia { get; set; }

        [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}", ErrorMessage = "O cnpj deve ter 14 caracteres sem pontuação. Exemplo: 12345678912345")]
        [Column("DS_CNPJ")]
        [Display(Name = "Cnpj do estabelecimento")]
        [MaxLength(14, ErrorMessage = "O cnpj deve ter 14 caracteres sem pontuação.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("DS_ENDERECO")]
        [Display(Name = "Qual o endereço do seu estabelecimento?")]
        [MinLength(10, ErrorMessage = "O campo de endereço deve ter 10 caracteres ou mais.")]
        [MaxLength(100, ErrorMessage = "O endereço deve ter menos de 100 caracteres")]
        public string Endereco { get; set; }

        [RegularExpression(@"(^[0-9]{2})([9]{1})?([0-9]{8})", ErrorMessage = "O telefone deve ter 11 caracteres sem pontuação (ddd + número). Ex: 11912345678.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("NR_TELEFONE")]
        [Display(Name = "Qual o telefone do seu estabelecimento?")]
        [MaxLength(11, ErrorMessage = "O telefone deve ter exatamente 11 caracteres")]
        public string Telefone { get; set; }

        [EmailAddress]
        [MaxLength(40, ErrorMessage = "O email deve ter menos de 40 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("DS_EMAIL")]
        [Display(Name = "Qual o email do seu estabelecimento?")]
        public string Email { get; set; }
    }
}
