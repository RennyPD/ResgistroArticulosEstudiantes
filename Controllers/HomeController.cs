using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZZZZRegistroArticulos.Models;
using System.Reflection.Metadata.Ecma335;
using ZZZZRegistroArticulos.Models.ViewModels;

namespace ZZZZRegistroArticulos.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestionArtcContext _DBcontext;

        public HomeController(GestionArtcContext context)
        {
            _DBcontext = context;
        }

        public IActionResult Index()
        {
            List<Articulo> lista = _DBcontext.Articulos.ToList();
            return View(lista);
        }

        [HttpGet]

        public IActionResult Articulo_Detalle(int IdArticulo)
        {
            ArticuloVM oArticuloVM = new ArticuloVM()
            {
                oArticulo = new Articulo()
            };

            if (IdArticulo != 0)
            {

                oArticuloVM.oArticulo = _DBcontext.Articulos.Find(IdArticulo);
            }

                return View(oArticuloVM);
        }

        [HttpPost]
        public IActionResult Articulo_Detalle(ArticuloVM oArticuloVM)
        {
            if (oArticuloVM.oArticulo.IdArticulo == 0)
            {
                _DBcontext.Articulos.Add(oArticuloVM.oArticulo);

            }
            else
            {
                _DBcontext.Articulos.Update(oArticuloVM.oArticulo);
            }


            _DBcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idArticulo)
        {
            Articulo oArticulo = _DBcontext.Articulos.Where(e => e.IdArticulo == idArticulo).FirstOrDefault();

            return View(oArticulo);
        }

        [HttpPost]
        public IActionResult Eliminar(Articulo oArticulo)
        {
            _DBcontext.Articulos.Remove(oArticulo);
            _DBcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}