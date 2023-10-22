using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public ActionResult Index()
        {
            
            return View(Utils.Utils.ListaProdctos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
       //AQUI GUARDA  DEK CREAR PRODCUTOS
        public ActionResult Create(Producto producto)
        {
            int i = Utils.Utils.ListaProdctos.Count() + 1;
            producto.IdProducto = i;
            Utils.Utils.ListaProdctos.Add(producto);
            return RedirectToAction("Index");
            
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int IdProducto)
        {
            Producto producto = Utils.Utils.ListaProdctos.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            Producto producto2 = Utils.Utils.ListaProdctos.Find(x => x.IdProducto == producto.IdProducto);
            if (producto2 != null)
            {
                producto2.Nombre=producto.Nombre;
                producto2.Descripcion=producto.Descripcion;
                producto2.cantidad=producto.cantidad;

                return RedirectToAction("Index");
            }
            return View();
        }




        public ActionResult Delete(int IdProducto)
        {
            Producto producto2 = Utils.Utils.ListaProdctos.Find(x => x.IdProducto == IdProducto);
            if (producto2 != null)
            {
                Utils.Utils.ListaProdctos.Remove(producto2);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");





        }
    }
}
