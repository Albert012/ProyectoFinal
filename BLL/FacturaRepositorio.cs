using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public class FacturaRepositorio : Repositorio<Facturas>
    {
        public override Facturas Buscar(int id)
        {
            Facturas facturas = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Facturas.Find(id);
                
                if(facturas != null)
                {
                    facturas.Detalles.Count();
                    foreach (var item in facturas.Detalles)
                    {
                        string p = item.Producto.Descripcion;
                    }
                }

                

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return facturas;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Ant = contexto.Facturas.Find(id);
                if(Ant != null)
                {
                    contexto.FacturasDetalles.RemoveRange(contexto.FacturasDetalles.Where(x => x.FacturaId == Ant.FacturaId));
                    contexto.Entry(Ant).State = EntityState.Deleted;

                    if(contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }

            }
            catch(Exception)
            {

            }
            finally
            {
                contexto.Dispose();
            }
            


            return paso;
        }

        public override List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturas> lista = new List<Facturas>();
            try
            {
                lista = contexto.Facturas.Where(expression).ToList();
                foreach (var item in lista)
                {
                    item.Detalles.Count();
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public override bool Guardar(Facturas entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Facturas.Add(entity) != null)
                {

                    foreach (var item in entity.Detalles)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }

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

        public override bool Modificar(Facturas factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //contexto.Entry(entity).State = EntityState.Detached;
                //contexto.Entry(entity).State = EntityState.Modified;
                var FacturaAnt = contexto.Facturas.Find(factura.FacturaId);

                /*foreach (var item in FacturaAnt.Detalles)
                {
                    //var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    if (!factura.Detalles.ToList().Exists(f => f.Id == item.Id))
                    {
                        item.Producto = null;
                        contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;

                    }
                }

                foreach (var item in factura.Detalles)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }*/
                contexto.FacturasDetalles.RemoveRange(contexto.FacturasDetalles.Where(x => x.FacturaId == FacturaAnt.FacturaId));
                contexto.Entry(FacturaAnt).State = EntityState.Deleted;

                contexto.Entry(factura).State = EntityState.Modified;

                if(contexto.SaveChanges()>0)
                {
                    paso = true;
                }
                

            }
            catch(Exception )
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }        
            

            return paso;
        }
    }
}
