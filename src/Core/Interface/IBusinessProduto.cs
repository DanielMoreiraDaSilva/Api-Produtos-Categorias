using System;
using System.Collections.Generic;
using Lab.Core.Model;

namespace Lab.Core
{
    public interface IBusinessProduto
    {
        List<Produto> GetAll();
        Produto GetById(Guid id);
        Produto GetDescricao(String descricao);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Guid id);
    }
}