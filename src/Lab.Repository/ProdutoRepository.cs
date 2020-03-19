using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Core;
using Lab.Core.Model;

namespace Lab.Repository
{
    public class ProdutoRepository : IProduto
    {
        private readonly Contexto contexto;
        public ProdutoRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public void Add(Produto produto)
        {
            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var produto = contexto.Produtos.Find(id);
            contexto.Produtos.Remove(produto);
            contexto.SaveChanges();
        }

        public Produto GetDescricao(String descricao)
        {
            var produto = contexto.Produtos.SingleOrDefault(c => c.Descricao == descricao);
            return produto;
        }

        public List<Produto> GetAll()
        {
            return contexto.Produtos.ToList();
        }

        public Produto GetById(Guid id)
        {
            return contexto.Produtos.Find(id);
        }

        public void Update(Produto produto)
        {
            contexto.Produtos.Update(produto);
            contexto.SaveChanges();            
        }
    }
}