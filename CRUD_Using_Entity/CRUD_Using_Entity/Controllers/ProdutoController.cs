using System.Linq;
using System.Web.Mvc;
using CRUD_Using_Entity.Dados;
using CRUD_Using_Entity.Models;

namespace CRUD_Using_Entity.Controllers
{
    public class ProdutoController : Controller
    {
        private Contexto Db = new Contexto();
        // GET: Produto
        public ActionResult Index()
        {
            var produtos = Db.Produtos.ToList();
            return View(produtos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            Db.Produtos.Add(produto);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var produto = Db.Produtos.Find(id);
            return View(produto);
        }
       
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            var produtos = Db.Produtos.Find(produto.Id);
            produtos.Nome = produto.Nome;
            produtos.Categoria = produto.Categoria;
            produtos.Valor = produto.Valor;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var produtos = Db.Produtos.Find(id);
            return View(produtos);
        }

        public ActionResult Delete(int id)
        {
            return View(Db.Produtos.Find(id));
        }
        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            var produtos = Db.Produtos.Find(produto.Id);
            Db.Produtos.Remove(produtos);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
