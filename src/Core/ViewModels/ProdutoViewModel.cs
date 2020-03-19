using System;
using Lab.Core.Model;

namespace Lab.Core.Mv
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set;}
        public string Codigo {get; set;}
        public Categoria Categoria {get; set;}
        public string Descricao {get; set;}
        public decimal Preco {get;set;}
        public string UnidadeMedida {get; set;}

    }
}