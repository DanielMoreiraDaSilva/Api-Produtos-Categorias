using System;
using System.Collections.Generic;
using Lab.Core;
using Lab.Core.Model;
using Lab.Repository;

namespace Lab.Business
{
    public class BusinessProduto : IBusinessProduto
    {
        private readonly IProduto produtoRepository;
        public BusinessProduto(IProduto produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }
        public void Add(Produto produto)
        {
            // if (produto.Codigo.Length == 4 && produto.Preco >= 0)
            // {
                produtoRepository.Add(produto);
            // }
        }

        public void Delete(Guid id)
        {
            produtoRepository.Delete(id);
        }

        public Produto GetDescricao(string codigo)
        {
            return produtoRepository.GetDescricao(codigo);
        }

        public List<Produto> GetAll()
        {
            return produtoRepository.GetAll();
        }

        public Produto GetById(Guid id)
        {
            return produtoRepository.GetById(id);
        }

        public void Update(Produto produto)
        {
            // if (produto.Codigo.Length == 4 && produto.Preco >= 0)
            // {
                produtoRepository.Update(produto);
            // }
        }
    }
}