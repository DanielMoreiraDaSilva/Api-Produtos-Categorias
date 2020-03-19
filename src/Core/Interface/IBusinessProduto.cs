using System;
using System.Collections.Generic;
using Lab.Core.Mv;
using Lab.Core.Model;

namespace Lab.Core
{
    public interface IBusinessProduto
    {
        List<ProdutoViewModel> GetAll();
        Produto GetById(Guid id);
        Produto GetDescricao(String descricao);
        void Add(ProdutoViewModel produto);
        void Update(Produto produto);
        void Delete(Guid id);
    }
}