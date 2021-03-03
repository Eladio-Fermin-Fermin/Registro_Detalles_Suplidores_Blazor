
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
    public class OrdenesBLL
    {
        private Contexto contexto { get; set; }
        private ProductosBLL productosBLL { get; set; }

        public OrdenesBLL(Contexto contexto)
        {
            this.contexto = contexto;
            productosBLL = new ProductosBLL(this.contexto);

        }

        

        public async Task<bool> Existe(int id)
        {
            bool ok = false;

            try
            {
                ok = await contexto.Ordenes.AnyAsync(o => o.OrdenId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Ordenes orden)
        {
            bool ok = false;

            try
            {

                await contexto.Ordenes.AddAsync(orden);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Ordenes orden)
        {
            bool ok = false;
            try
            {

                contexto.Database.ExecuteSqlRaw($"DELETE FROM OrdenesDetalle WHERE OrdenId={orden.OrdenId}");
                foreach (var item in orden.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;

                }

                contexto.Entry(orden).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<bool> Guardar(Ordenes orden)
        {
            if (!await Existe(orden.OrdenId))
                return await Insertar(orden);
            else
                return await Modificar(orden);
        }

        public async Task<Ordenes> Buscar(int id)
        {
            Ordenes orden;
            try
            {
                orden = await contexto.Ordenes.Where(o => o.OrdenId == id)
                    .Include(d => d.Detalle).AsNoTracking()
                    .SingleOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }

            return orden;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;
            try
            {
                var registro = await Buscar(id);

                if (registro != null)
                {
                    contexto.Ordenes.Remove(registro);
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Ordenes>> GetOrdenes(Expression<Func<Ordenes, bool>> criterio)
        {
            List<Ordenes> lista = new List<Ordenes>();

            try
            {
                lista = await contexto.Ordenes.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

    }
}
