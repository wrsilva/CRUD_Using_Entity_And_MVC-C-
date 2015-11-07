using System.Linq;
using System.Web.Mvc;
using CRUD_Using_Entity.Models;
using CRUD_Using_Entity.Contexto;

namespace CRUD_Using_Entity.Controllers
{
    public class ProdutoController : Controller
    {
        
        private readonly ProdutoContexto _proContexto = new ProdutoContexto();
        // GET: Produto
        public ActionResult Index()
        {
            //Listar Todos Produtos
            return View(_proContexto.ListaTodos);
            //Listar Apenas Produtos Ativos
            //return View(_proContexto.ListaAtivos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            _proContexto.SalvarEditar(produto);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Produto prod = _proContexto.ListaTodos.FirstOrDefault(p=>p.Id == id);
          
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            _proContexto.SalvarEditar(produto); 
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Produto prod = _proContexto.ListaTodos.FirstOrDefault(p => p.Id == id);
            return View(prod);
        }

        public ActionResult Delete(int id)
        {
            Produto prod = _proContexto.ListaTodos.FirstOrDefault(p=>p.Id == id);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
           _proContexto.Deletar(produto.Id);
            return RedirectToAction("Index");
        }
    }
}
