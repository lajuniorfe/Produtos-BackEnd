using Microsoft.AspNetCore.Mvc;
using Produtos.Model;
using Produtos.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProduto _produto;

        public ProdutoController(IProduto produto)
        {
            _produto = produto;
        }

        [HttpPut("alterar/{idproduto}")]
        public IActionResult AlterarProduto(int IdProduto, [FromBody] ProdutoModel produto)
        {
            try
            {
                var ProdutoRetornado = _produto.RetornarProdutosId(IdProduto);
                if (ProdutoRetornado != null)
                {
                    ProdutoRetornado.Ativo = produto.Ativo;
                    ProdutoRetornado.DescricaoProduto = produto.DescricaoProduto.ToUpper();
                    ProdutoRetornado.NomeProduto = produto.NomeProduto.ToUpper();

                    _produto.AlterarProdutos(ProdutoRetornado);

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("data/{data}")]
        public IActionResult RetornarProdutosData(DateTime Data)
        {
            try
            {
                var ProdutoRetornado = _produto.RetornarProdutosData(Data);
                if (ProdutoRetornado != null)
                {
                    return new ObjectResult(ProdutoRetornado);
                }
                else
                {
                    return NotFound();
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("periodo/{datainicio}/{datafim}")]
        public IActionResult RetornarProdutosPeriodo(DateTime DataInicio, DateTime DataFim)
        {
            try
            {
                var ProdutosRetornado = _produto.RetornarProdutosPeriodos(DataInicio, DataFim);
                if (ProdutosRetornado != null)
                {
                    return new ObjectResult(ProdutosRetornado);

                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{idproduto}")]
        public IActionResult RetornarProdutoId(int IdProduto)
        {
            try
            {
                var RetornoProdutos = _produto.RetornarProdutosId(IdProduto);
                if (RetornoProdutos != null)
                {
                    return new ObjectResult(RetornoProdutos);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarProduto([FromBody] ProdutoModel produto)
        {
            try
            {
                produto.DataCriacao = DateTime.Now;

                _produto.CadastrarProdutos(produto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult RetornarProdutos()
        {
            try
            {
                var RetornarProdutos = _produto.RetornarTodosProdutos();
                if (RetornarProdutos != null)
                {
                    return new ObjectResult(RetornarProdutos);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("nome/{nomeproduto}")]
        public IActionResult RetornarProdutosNome(string NomeProduto)
        {
            try
            {
                var ProdutoRetornado = _produto.RetornarProdutosNome(NomeProduto.ToUpper());
                if (ProdutoRetornado != null && ProdutoRetornado.Count() > 0)
                {
                    return new ObjectResult(ProdutoRetornado);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
