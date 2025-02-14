using Microsoft.AspNetCore.Mvc;
using SistemaInventarioV7.AccesoDatos.Repositorio;
using SistemaInventarioV7.AccesoDatos.Repositorio.IRepositorio;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SistemaInventarioNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodegaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private object todos;

        public BodegaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Bodega.ObtenerTodos();
            return Json(new { data = todos });
        }
        #endregion
    }
}
