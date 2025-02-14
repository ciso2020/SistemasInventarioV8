using SistemaInventario.AccesoDatos.Repositorio;
using SistemaInventarioNet7.AccesoDatos.Data;
using SistemaInventarioV7.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioV7.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
 

        private readonly ApplicationDbContext _db;
        private IBodegaRepositorio bodega;

        public IBodegaRepositorio Bodega { get => bodega; private set => bodega = value; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public UnidadTrabajo(ApplicationDbContext db)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
                }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
