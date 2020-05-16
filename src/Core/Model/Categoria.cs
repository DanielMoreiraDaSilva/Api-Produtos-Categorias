using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab.Core.Model
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public DateTime criadoEm { get; set; }

    }
}