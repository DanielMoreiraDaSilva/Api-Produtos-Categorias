using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Core.Model
{
    public class Produto
    {
        public Produto()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set;}
        public string Codigo {get; set;}
        public Categoria Categoria {get; set;}
        public string Descricao {get; set;}
        public decimal Preco {get;set;}
        public string UnidadeMedida {get; set;}

    }
}