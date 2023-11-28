using System.ComponentModel.DataAnnotations;

namespace AjCorpWebApp.Models
{
    
    public class Produto
    {
        
        public int ProdutoId { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required string ImagemUri { get; set; }
        public required string Duracao { get; set; }

        [Display(Name = "Valor")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Display(Name = "Inicio Imediato")]
        public bool Inicio { get; set; }
        public string InicioEditado => Inicio ? "Sim" : "Nao";

		[Display(Name = "Marca")]
		public int? MarcaId { get; set; }
    }
}
