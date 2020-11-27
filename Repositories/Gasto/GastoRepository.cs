﻿using Entities.EDMX;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class GastoRepository : BaseRepository<Gasto>, IGastoRepository
    {
        public GastoRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }
        public override void Modificar(Gasto t)
        {
            Gasto gasto = ObtenerPorId(t.IdGasto);
            gasto.MesExpensa = t.MesExpensa;
            gasto.Monto = t.Monto;
            gasto.Nombre = t.Nombre;
            gasto.IdConsorcio = t.IdConsorcio;
            gasto.IdTipoGasto = t.IdTipoGasto;
            gasto.IdUsuarioCreador = t.IdUsuarioCreador;
            gasto.TipoGasto = t.TipoGasto;
            gasto.Usuario = t.Usuario;

            ctx.SaveChanges();

        }
        public List<Gasto> ObtenerGastosPorConsorcio(int id)
        {
            var gasto = from Gasto in ctx.Gastoes
                        where Gasto.IdConsorcio == id
                        select Gasto;
            List<Gasto> gastosPorConsorcio = gasto.ToList();

            return gastosPorConsorcio;
        }
    }
}