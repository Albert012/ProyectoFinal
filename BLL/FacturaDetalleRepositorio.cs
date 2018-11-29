using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class FacturaDetalleRepositorio : Repositorio<FacturasDetalles>
    {
        public override bool Guardar(FacturasDetalles entity)
        {
            return base.Guardar(entity);
        }

        public override bool Modificar(FacturasDetalles entity)
        {
            return base.Modificar(entity);
        }

        public override bool Eliminar(int id)
        {
            return base.Eliminar(id);
        }

        public override FacturasDetalles Buscar(int id)
        {
            return base.Buscar(id);
        }

        public override List<FacturasDetalles> GetList(Expression<Func<FacturasDetalles, bool>> expression)
        {
            return base.GetList(expression);
        }
    }
}
