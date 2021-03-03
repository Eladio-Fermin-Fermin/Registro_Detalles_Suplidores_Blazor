using Microsoft.EntityFrameworkCore;
using Registro_Detalles_Suplidores_Blazor.DAL;
using Registro_Detalles_Suplidores_Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Registro_Detalles_Suplidores_Blazor.BLL
{
    public class ProductosBLL
    {
        private Contexto contexto { get; set; }

        public ProductosBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        private async Task<bool> Existe(int id)
        {
            bool ok = false;

            try
            {
                ok = await contexto.Productos.AnyAsync(p => p.ProductoId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Productos producto)
        {
            bool ok = false;

            try
            {
                await contexto.Productos.AddAsync(producto);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Productos producto)
        {
            bool ok = false;

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;

        }
        public async Task<bool> Guardar(Productos producto)
        {
            if (!await Existe(producto.ProductoId))
                return await Insertar(producto);
            else
                return await Modificar(producto);
        }

        public async Task<Productos> Buscar(int id)
        {
            Productos producto;

            try
            {
                producto = await contexto.Productos
                    .Where(s => s.ProductoId == id)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return producto;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;
            try
            {
                var registro = await Buscar(id);
                if (registro != null)
                {
                    contexto.Productos.Remove(registro);
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Productos>> GetProductos(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = await contexto.Productos.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
        
    }
}
