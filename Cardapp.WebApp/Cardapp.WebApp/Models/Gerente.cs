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
        public string CodigoGerente { get; set; }

        [Column("CD_ESTABELECIMENTO")]
        [HiddenInput]
        public string CodigoEstabelecimento { get; set; }

        [Column("NM_GERENTE")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome deve ter 2 caracteres ou mais.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter 50 caracteres ou menos.")]
        [Display(Name = "Qual é o nome do gerente?")]
        public string NomeGerente { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Column("DS_EMAIL")]
        [MaxLength(65, ErrorMessage = "O email deve ter 65 caracteres ou menos.")]
        [Display(Name = "Qual o email do gerente?")]
        public string Email { get; set; }

        [Column("DS_ENDERECO")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MinLength(10, ErrorMessage = "O endereço deve ter 10 caracteres ou mais.")]
        [MaxLength(150, ErrorMessage = "O endereço deve ter 150 caracteres ou menos.")]
        [Display(Name = "Qual o endereço do gerente?")]
        public string Endereco { get; set; }

        [Column("DS_SENHA")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "A senha deve ter 5 caracteres ou mais.")]
        [MaxLength(25, ErrorMessage = "A senha deve ter 25 caracteres ou menos.")]
        [Display(Name = "Informe a senha que será utilizada na sua conta")]
        public string Senha { get; set; }

    }
}