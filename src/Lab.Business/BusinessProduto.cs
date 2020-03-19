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
        public void Add(ProdutoViewModel produtoViewlModel)
        {
            // if (produto.Codigo.Length == 4 && produto.Preco >= 0)
            // {
            var produto = new Produto();
            produto.Id = produtoViewlModel.Id;
            produto.Codigo = produtoViewlModel.Codigo;
            produto.Descricao = produtoViewlModel.Descricao;
            produto.UnidadeMedida = produtoViewlModel.UnidadeMedida;
            produto.Preco = produtoViewlModel.Preco;
            if (produtoViewlModel.Categoria != null)
            {
                produto.CategoriaId = categoriaRepository.GetCategoria(produtoViewlModel.Categoria);
            }
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
                produtosViewModel.Add(produtoViewModel);
            }
            return produtosViewModel;
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