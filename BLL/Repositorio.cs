using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class Repositorio<T> : IRepository<T> where T : class
    {

        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                if (contexto.Set<T>().Add(entity) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                contexto.Entry(entity).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }



            return paso;
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                T entity = contexto.Set<T>().Find(id);
                contexto.Set<T>().Remove(entity);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public virtual T Buscar(int id)
        {
            T entity = null;
            Contexto contexto = new Contexto();
            try
            {

                entity = contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return entity;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> list = new List<T>();
            Contexto contexto = new Contexto();
            try
            {

                list = contexto.Set<T>().Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return list;
        }


    }
}
