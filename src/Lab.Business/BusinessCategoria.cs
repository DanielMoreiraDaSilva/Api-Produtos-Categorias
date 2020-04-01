using System;
using System.Collections.Generic;
using Lab.Core;
using Lab.Core.Model;
using Lab.Repository;

namespace Lab.Business
{
    public class BusinessCategoria : IBusinessCategoria
    {
        private readonly ICategoria categoriaRepository;

        public BusinessCategoria(ICategoria CategoriaRepository)
        {
            this.categoriaRepository = CategoriaRepository;
        }
        public void Add(Categoria categoria)
        {
            if (categoria.codigo.Length == 4)
            {
                categoriaRepository.Add(categoria);
            }
            else
            {
                throw new BusinessException("Não rolo cara");
            }
        }
        public void Delete(Guid id)
        {
            categoriaRepository.Delete(id);
        }

        public Categoria GetDescricao(string codigo)
        {
            var i = categoriaRepository.GetDescricao(codigo);
            if (i == null)
            {
                throw new Exception();
            }
            else
            {
                return i;
            }
        }

        public List<Categoria> GetAll()
        {
            return categoriaRepository.GetAll();
        }
        public Categoria GetById(Guid id)
        {
            var i = categoriaRepository.GetById(id);
            if (i == null)
            {
                throw new Exception();
            }
            else
            {
                return i;
            }
        }
        public void Update(Categoria categoria)
        {
            if (categoria.codigo.Length == 4)
            {
                categoriaRepository.Update(categoria);
            }
            else
            {
                throw new BusinessException();
            }
        }
    }
}