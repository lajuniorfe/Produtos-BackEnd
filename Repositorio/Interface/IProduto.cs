using Produtos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Repositorio.Interface
{
    public interface IProduto
    {
        public List<ProdutoModel> RetornarTodosProdutos();
        public List<ProdutoModel> RetornarProdutosNome(string NomeProduto);
        public ProdutoModel RetornarProdutosId(int IdProduto);
        public List<ProdutoModel> RetornarProdutosData(DateTime Data);
        public List<ProdutoModel> RetornarProdutosPeriodos(DateTime DataInicio, DateTime DataFim);
        public void CadastrarProdutos(ProdutoModel produtos);
        public void AlterarProdutos(ProdutoModel produtos);

    }
}
