using System;
using Lab.Core.Model;

namespace Lab.Core.DTO
{
    public class ProdutoDTO
    {
        public Guid Id { get; set;}
        public String Codigo {get; set;}
        public Categoria Categoria {get; set;}
        public String Descricao {get; set;}
        public Decimal Preco {get;set;}
        public String UnidadeMedida {get; set;}

    }
}