using System;
using System.Collections.Generic;
using Lab.Core;
using Lab.Core.Model;
using Lab.Core.Mv;
using Lab.Repository;

namespace Lab.Business
{
    public class BusinessProduto : IBusinessProduto
    {
        private readonly IProduto produtoRepository;
        private readonly ICategoria categoriaRepository;
        public BusinessProduto(IProduto produtoRepository, ICategoria categoriaRepository)
        {
            this.produtoRepository = produtoRepository;
            this.categoriaRepository = categoriaRepository;
        }
        public List<ProdutoViewModel> GetAll()
        {
            List<Produto> produtos = produtoRepository.GetAll();
            var produtosViewModel = new List<ProdutoViewModel>();
            for (int i = 0; i < produtos.Count; i++)
            {
                var produtoViewModel = new ProdutoViewModel();
                produtoViewModel.Codigo = produtos[i].Codigo;
                produtoViewModel.Descricao = produtos[i].Descricao;
                produtoViewModel.Id = produtos[i].Id;
                produtoViewModel.Preco = produtos[i].Preco;
                produtoViewModel.UnidadeMedida = produtos[i].UnidadeMedida;
                produtoViewModel.Categoria = categoriaRepository.GetById(produtos[i].CategoriaId);
                if (produtoViewModel.Categoria == null)
                {
                    produtoViewModel.Categoria = new Categoria();
                }
                produtosViewModel.Add(produtoViewModel);
            }
            return produtosViewModel;
        }
        public ProdutoViewModel GetById(Guid id)
        {
            var produto = produtoRepository.GetById(id);
            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Codigo = produto.Codigo;
            produtoViewModel.Descricao = produto.Descricao;
            produtoViewModel.Id = produto.Id;
            produtoViewModel.Preco = produto.Preco;
            produtoViewModel.UnidadeMedida = produto.UnidadeMedida;
            produtoViewModel.Categoria = categoriaRepository.GetById(produto.CategoriaId);
            if (produtoViewModel.Categoria == null)
            {
                produtoViewModel.Categoria = new Categoria();
            }
            return produtoViewModel;
        }
        public ProdutoViewModel GetDescricao(string codigo)
        {
            var produto = produtoRepository.GetDescricao(codigo);
            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Codigo = produto.Codigo;
            produtoViewModel.Descricao = produto.Descricao;
            produtoViewModel.Id = produto.Id;
            produtoViewModel.Preco = produto.Preco;
            produtoViewModel.UnidadeMedida = produto.UnidadeMedida;
            produtoViewModel.Categoria = categoriaRepository.GetById(produto.CategoriaId);
            if (produtoViewModel.Categoria == null)
            {
                produtoViewModel.Categoria = new Categoria();
            }
            return produtoViewModel;
        }
        public void Add(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Codigo.Length == 4 && produtoViewModel.Preco >= 0)
            {
                var produto = new Produto();
                produto.Id = produtoViewModel.Id;
                produto.Codigo = produtoViewModel.Codigo;
                produto.Descricao = produtoViewModel.Descricao;
                produto.UnidadeMedida = produtoViewModel.UnidadeMedida;
                produto.Preco = produtoViewModel.Preco;
                if (produtoViewModel.Categoria != null)
                {
                    produto.CategoriaId = categoriaRepository.GetCategoria(produtoViewModel.Categoria);
                }

                produtoRepository.Add(produto);
            }
        }
        public void Delete(Guid id)
        {
            produtoRepository.Delete(id);
        }
        public void Update(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.Codigo.Length == 4 && produtoViewModel.Preco >= 0)
            {
                var produto = new Produto();
                produto.Id = produtoViewModel.Id;
                produto.Codigo = produtoViewModel.Codigo;
                produto.Descricao = produtoViewModel.Descricao;
                produto.UnidadeMedida = produtoViewModel.UnidadeMedida;
                produto.Preco = produtoViewModel.Preco;
                if (produtoViewModel.Categoria != null)
                {
                    produto.CategoriaId = categoriaRepository.GetCategoria(produtoViewModel.Categoria);
                }
                produtoRepository.Update(produto);
            }
        }
    }
}