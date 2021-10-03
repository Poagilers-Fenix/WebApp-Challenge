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
        [Display(Name = "Qual o nome do gerente responsável pelo estabelecimento?")]
        public string NomeGerente { get; set; }

        [Column("DS_EMAIL")]
        [Display(Name = "Qual o email do gerente?")]
        public string Email { get; set; }

        [Column("VL_SALARIO")]
        [Display(Name = "Qual o valor do salário do gerente?")]
        public double Salario { get; set; }

        [Column("DS_ENDERECO")]
        [Display(Name = "Qual o endereço do gerente?")]
        public string Endereco { get; set; }

        [Column("DS_SENHA")]
        [Display(Name = "Informe a senha que será utilizada na sua conta")]
        public string Senha { get; set; }

    }
}
