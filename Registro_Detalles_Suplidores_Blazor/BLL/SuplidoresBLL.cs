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
    public class SuplidoresBLL
    {
        private Contexto contexto { get; set; }

        public SuplidoresBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> Guardar(Suplidores suplidor)
        {
            if (!await Existe(suplidor.SuplidorId))
                return await Insertar(suplidor);
            else
                return await Modificar(suplidor);
        }

        private async Task<bool> Existe(int id)
        {
            bool ok = false;

            try
            {
                ok = await contexto.Suplidores.AnyAsync(s => s.SuplidorId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Suplidores suplidor)
        {
            bool ok = false;

            try
            {
                await contexto.Suplidores.AddAsync(suplidor);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Suplidores suplidor)
        {
            bool ok = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;

        }

        public async Task<Suplidores> Buscar(int id)
        {
            Suplidores suplidor;

            try
            {
                suplidor = await contexto.Suplidores
                    .Where(s => s.SuplidorId == id)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return suplidor;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;
            try
            {
                var registro = await contexto.Suplidores.FindAsync(id);
                if (registro != null)
                {
                    contexto.Entry(registro).State = EntityState.Deleted;
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Suplidores>> GetSuplidores(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();

            try
            {
                lista = await contexto.Suplidores.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

    }
}