using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
        T Buscar(int id);
        List<T> GetList(Expression<Func<T, bool>> expression);
    }
}
