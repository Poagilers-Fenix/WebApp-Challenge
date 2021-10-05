using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cardapp.WebApp.Models
{
    [Table("T_CPP_GERENTE")]
    public class Gerente
    {
        [Key]
        [Column("CD_GERENTE")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoGerente { get; set; }

        [Column("CD_ESTABELECIMENTO")]
        public int CodigoEstabelecimento { get; set; }

        [Column("NM_GERENTE")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter 50 caracteres ou menos.")]
        [Display(Name = "Qual o nome do gerente responsável pelo estabelecimento?")]
        public string NomeGerente { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("DS_EMAIL")]
        [MaxLength(65, ErrorMessage = "O email deve ter 65 caracteres ou menos.")]
        [Display(Name = "Qual o email do gerente?")]
        public string Email { get; set; }

        [Column("VL_SALARIO")]
        [RegularExpression(@"(^[0-9]{0,5}[,][0-9]{2})", ErrorMessage = "O salário deve ser somente números. Ex: 1000,00.")]
        [Display(Name = "Qual o valor do salário do gerente?")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal? Salario { get; set; }

        [Column("DS_ENDERECO")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O endereço deve ter 150 caracteres ou menos.")]
        [Display(Name = "Qual o endereço do gerente?")]
        public string Endereco { get; set; }

        [Column("DS_SENHA")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.Password)]
        [MaxLength(25, ErrorMessage = "A senha deve ter 25 caracteres ou menos.")]
        [Display(Name = "Informe a senha que será utilizada na sua conta")]
        public string Senha { get; set; }

        public string id_Gerente_Firebase { get; set; }


    }
}