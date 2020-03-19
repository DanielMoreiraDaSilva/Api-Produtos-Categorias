using System;
using System.Collections.Generic;
using Lab.Core;
using Lab.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab.Repository
{
    public class CategoriaRepository : ICategoria
    {
        private readonly Contexto db;
        public CategoriaRepository(Contexto contexto)
        {
            this.db = contexto;
        }
        public void Add(Categoria categoria)
        {
            categoria.Id = Guid.NewGuid();
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var produto = db.Categorias.Find(id);
            db.Remove(produto);
            db.SaveChanges();
        }
        public Categoria GetDescricao(String descricao)
        {
            var produto = db.Categorias.FirstOrDefault(c => c.descricao == descricao);
            return produto;
        }
        public Guid GetCategoria(Categoria categoria)
        {
            if(categoria != null)
            {
            var c = db.Categorias.Find(categoria.Id);
            return c.Id;
            }
            else
            {
                Guid nulo = Guid.Empty;
                return nulo;
            }      
        }
        public List<Categoria> GetAll()
        {
            return db.Categorias.ToList();
        }
        public Categoria GetById(Guid id)
        {
            return db.Categorias.Find(id);
        }
        public void Update(Categoria categoria)
        {
            db.Categorias.Update(categoria);
            db.SaveChanges();
        }
    }
}