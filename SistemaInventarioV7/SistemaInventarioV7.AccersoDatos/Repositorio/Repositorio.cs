using Microsoft.EntityFrameworkCore;
using PagedList;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioNet7.AccesoDatos.Data;
using SistemaInventarioV7.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SistemaInventarioV7.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();

        }

        public async Task Agregar(T endidad)
        {
            await dbSet.AddAsync(endidad);    //Insert into table
        }

        public async Task<T> Obtener(int id)
        {
            T? t = await dbSet.FindAsync(id);
            return t;
        }     //select from id


        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>>? filtro = null, 
            string? incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);   //  select /* from where ....
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }
            
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            T? t = await query.FirstOrDefaultAsync();
            return t;


        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);   //  select /* from where ....
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);    //  ejemplo "Categoria,Marca"
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();

        }

        public PagedList<T> ObtenerTodosPaginado(Parameter parametros, Expression<Func<T, bool>>? filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? incluirPropiedades = null, bool isTracking = true)
        {
            throw new NotImplementedException();
        }

        public void Remover(T endidad)
        {
            dbSet.Remove(endidad);
        }

        public void RemoverRango(IEnumerable<T> endidad)
        {
            dbSet.RemoveRange(endidad);
        }
    }
}
