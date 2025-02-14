using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioV7.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioV7.AccesoDatos.Repositorio.IRepositorio
{
    public interface IBodegaRepositorio : IRepositorio<Bodega>
    {
        void actualizar(Bodega bodega);
        Task ObtenerTodos();
    }
}
