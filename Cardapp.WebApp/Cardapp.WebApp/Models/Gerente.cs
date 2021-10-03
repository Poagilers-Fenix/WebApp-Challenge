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
        [Display(Name = "Qual o nome do gerente responsável pelo estabelecimento?")]
        public Estabelecimento Estabelecimento { get; set; }

        [Column("NM_GERENTE")]
        [MaxLength(50, ErrorMessage = "O nome deve ter 50 caracteres ou menos.")]
        [Display(Name = "Qual o nome do gerente responsável pelo estabelecimento?")]
        public string NomeGerente { get; set; }

        [EmailAddress]
        [Column("DS_EMAIL")]
        [MaxLength(65, ErrorMessage = "O email deve ter 65 caracteres ou menos.")]
        [Display(Name = "Qual o email do gerente?")]
        public string Email { get; set; }

        [Column("VL_SALARIO")]
        [Range(0, 99999)]
        [Display(Name = "Qual o valor do salário do gerente?")]
        public double Salario { get; set; }

        [Column("DS_ENDERECO")]
        [MaxLength(150, ErrorMessage = "O endereço deve ter 150 caracteres ou menos.")]
        [Display(Name = "Qual o endereço do gerente?")]
        public string Endereco { get; set; }

        [Column("DS_SENHA")]
        [DataType(DataType.Password)]
        [MaxLength(25, ErrorMessage = "A senha deve ter 25 caracteres ou menos.")]
        [Display(Name = "Informe a senha que será utilizada na sua conta")]
        public string Senha { get; set; }

    }
}
