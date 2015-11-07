using System.Collections.Generic;
using System.Linq;
using CRUD_Using_Entity.Models;

namespace CRUD_Using_Entity.Contexto
{
    public class ProdutoContexto
    {
       private readonly Contexto _contexto = new Contexto();

        public IEnumerable<Produto> ListaTodos
        {
            get{ return _contexto.Produtos.ToList();}
        }
        public IEnumerable<Produto> ListaAtivos        {
            get { return ListaTodos.Where(p => p.Status == true); }
        }

        public void SalvarEditar(Produto produto)
        {
            if (produto.Id != 0)
            {
                var prod = _contexto.Produtos.Find(produto.Id);
                prod.Nome = produto.Nome;
                prod.Categoria = produto.Categoria;
                prod.Valor = produto.Valor;
                prod.Status = produto.Status;
                _contexto.SaveChanges();
            }
            else
            {
                _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var prod = _contexto.Produtos.Find(id);
            _contexto.Produtos.Remove(prod);
            _contexto.SaveChanges();
        }
    }
}