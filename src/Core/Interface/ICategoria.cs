using System;
using System.Collections.Generic;
using Lab.Core.Model;

namespace Lab.Core
{
    public interface ICategoria
    {
        List<Categoria> GetAll();
        Categoria GetById(Guid id);
        Categoria GetDescricao(String descricao);    
        void Add(Categoria categoria);    
        void Update(Categoria categoria);
        void Delete(Guid id);
    }
}