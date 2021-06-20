using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Produtos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Contexto
{
    public class ClasseContexto : DbContext
    {
        public ClasseContexto(DbContextOptions<ClasseContexto> options) : base(options)
        {

        }

        public DbSet<ProdutoModel>Produto { get; set; }

    }
}
