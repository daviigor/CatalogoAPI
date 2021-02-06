using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public String Descricao { get; set; }
        public int? IdCategoria { get; set; }
        public bool Ativo { get; set; }
        public int Estoque { get; set; }
        public Decimal Preco { get; set; }
        public String ImagemURL { get; set; }

    }
}
