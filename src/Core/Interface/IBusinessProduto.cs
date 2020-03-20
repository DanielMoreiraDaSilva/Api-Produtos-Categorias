using System;
using System.Collections.Generic;
using Lab.Core.Mv;
using Lab.Core.Model;

namespace Lab.Core
{
    public interface IBusinessProduto
    {
        List<ProdutoViewModel> GetAll();
        ProdutoViewModel GetById(Guid id);
        ProdutoViewModel GetDescricao(String descricao);
        void Add(ProdutoViewModel produto);
        void Update(ProdutoViewModel produtoViewModel);
        void Delete(Guid id);
    }
}