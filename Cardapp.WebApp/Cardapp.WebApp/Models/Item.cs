using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cardapp.WebApp.Models
{
    [Table("T_CPP_ITEM_CARDAPIO")]
    public class Item
    {
        [Key]
        [Column("CD_ITEM_CARDAPIO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoItem { get; set; }
        [Column("CD_ESTABELECIMENTO")]
        public int CodigoEstabelecimento { get; set; }
        [Column("CD_CATEGORIA")]
        public int CodigoCategoria { get; set; }

        [Column("ST_DESTAQUE")]
        [Display(Name = "Destaque")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public char Destaque { get; set; }

        [Column("NM_ITEM_CARDAPIO")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome do item deve ter 50 caracteres ou menos.")]
        public string Nome { get; set; }

        [Column("DS_ITEM_CARDAPIO")]
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(300, ErrorMessage = "A descrição do item deve ter 300 caracteres ou menos.")]
        public string Descricao { get; set; }

        [Column("VL_ITEM_CARDAPIO")]
        [RegularExpression(@"(^[0-9]{0,5}[,][0-9]{2})", ErrorMessage = "O salário deve ser somente números. Ex: 1000,00.")]
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public decimal Preco { get; set; }

        [Column("VL_CALORICO")]
        [RegularExpression(@"(^[0-9]{0,4})", ErrorMessage = "O valor calórico deve ser somente números. Ex: 1009.")]
        [Display(Name = "Valor calórico")]
        public int ValCalorico { get; set; }

        [Column("FL_FOTO_IC")]
        [Display(Name = "Foto")]
        [MaxLength(1000, ErrorMessage = "A url de imagem do item deve ter 1000 caracteres ou menos.")]
        public string Foto { get; set; }

        //public string id_ItemCardapio_Firebase { get; set; }

    }
}