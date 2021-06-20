using Microsoft.Extensions.Configuration;
using Produtos.Contexto;
using Produtos.Model;
using Produtos.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Produtos.Repositorio
{
    public class ProdutoRepositorio : IProduto
    {
        private readonly ClasseContexto _contexto;

        public ProdutoRepositorio(ClasseContexto contexto)
        {
            _contexto = contexto;
        }

        public void AlterarProdutos(ProdutoModel produtos)
        {
            try
            {
                _contexto.Produto.Update(produtos);
                _contexto.SaveChanges();
            }
            catch
            {
                throw;
            }
          
        }

        public void CadastrarProdutos(ProdutoModel produtos)
        {
            try
            {
                _contexto.Produto.Add(produtos);
                _contexto.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<ProdutoModel> RetornarProdutosData(DateTime Data)
        {
            try
            {
                var RetornoProduto = _contexto.Produto.OrderBy(p => p.DataCriacao.Date)
                                                      .Where(p => p.DataCriacao.Date == Data.Date).ToList();

                return RetornoProduto;
            }
            catch
            {
                throw;
            }
        }

        public ProdutoModel RetornarProdutosId(int IdProduto)
        {
            try
            {
                var RetornoProduto = _contexto.Produto.Where(p => p.IdProduto == IdProduto).FirstOrDefault();

                return RetornoProduto;

            }
            catch
            {
                throw;
            }
           
        }

        public List<ProdutoModel> RetornarProdutosNome(string NomeProduto)
        {
            try
            {
                var RetornoProduto = _contexto.Produto.OrderBy(p => p.NomeProduto)
                                                        .Where(p => p.NomeProduto.Contains(NomeProduto.ToUpper())).ToList();

                return RetornoProduto;
            }
            catch
            {
                throw;
            }
        }

        public List<ProdutoModel> RetornarProdutosPeriodos(DateTime DataInicio, DateTime DataFim)
        {
            try
            {
                var RetornoPeriodo = _contexto.Produto.OrderBy(p => p.DataCriacao.Date)
                                                       .Where(p => p.DataCriacao.Date >= DataInicio.Date || p.DataCriacao.Date <= DataFim.Date)
                                                       .ToList();

                return RetornoPeriodo;
            }
            catch
            {
                throw;
            }
        }

        public List<ProdutoModel> RetornarTodosProdutos()
        {
            try
            {
                var RetornoProduto = _contexto.Produto.ToList();
                return RetornoProduto;
            }
            catch
            {
                throw;
            }
        }
    }
}
