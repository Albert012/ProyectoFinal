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
        public bool Guardar(T entity)
        {
            bool paso = false;
            ContextoRepositorio<T> contexto = new ContextoRepositorio<T>();
            try
            {
                contexto.Entity.Add(entity);


                if (entity.GetType() == typeof(Facturas))
                {
                    
                    foreach (FacturasDetalles item in (entity as Facturas).Detalles)
                    {
                        contexto.Detalle.Add(item);
                    }
                }
                contexto.SaveChanges();
                paso = true;
                
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

        public bool Modificar(T entity)
        {
            bool paso = false;
            ContextoRepositorio<T> contexto = new ContextoRepositorio<T>();
            try
            {                
                contexto.Entry(entity).State = EntityState.Modified;

                if (entity.GetType() == typeof(Facturas))
                {
                    foreach (FacturasDetalles item in (entity as Facturas).Detalles)
                    {
                        var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;

                        if ((entity as Facturas).Detalles.ToList().Exists(f => f.Id == item.Id))
                        {
                            
                            contexto.Entry(item).State = estado;

                        }
                        else                           
                            contexto.Detalle.Add(item);

                    }

                    
                }
                contexto.Entry(entity).State = EntityState.Modified;
                contexto.SaveChanges();
                paso = true;
                
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

        public bool Eliminar(int id)
        {
            bool paso = false;
            ContextoRepositorio<T> contexto = new ContextoRepositorio<T>();
            try
            {
                T entity = contexto.Entity.Find(id);

                if (entity is Facturas)
                {

                    contexto.Detalle.RemoveRange(contexto.Detalle.Where(f => f.FacturaId == id));
                }

                contexto.Entity.Remove(entity);
                contexto.SaveChanges();
                paso = true;                
                
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

        public T Buscar(int id)
        {
            T entity = null;
            ContextoRepositorio<T> contexto = new ContextoRepositorio<T>();
            try
            {                

                entity = contexto.Entity.Find(id);

                if (entity != null)
                {
                    if (entity.GetType() == typeof(Facturas))
                    {
                        //(entity as Facturas).Detalles.Count();
                        foreach (var item in (entity as Facturas).Detalles)
                        {
                            string p = item.Producto.Descripcion;
                        }
                        (entity as Facturas).Detalles = contexto.Detalle.Where(f => f.FacturaId == id).ToList();                       

                    }
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

            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> list = null;
            
            ContextoRepositorio<T> contexto = new ContextoRepositorio<T>();
            try
            {
                list = contexto.Entity.Where(expression).ToList();             
                
            }
            catch(Exception)
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
