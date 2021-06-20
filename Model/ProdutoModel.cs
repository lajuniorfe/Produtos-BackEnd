using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Model
{
    [Table("produto")]
    public class ProdutoModel
    {
        [Key, Column("id_produto")]
        public int IdProduto { get; set; }

        [Column("nome")]
        public string NomeProduto { get; set; }

        [Column("descricao")]
        public string DescricaoProduto { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("data")]
        public DateTime DataCriacao { get; set; }
    }
}
