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
    public class FacturasBLL 
    {
        public static bool Guardar(Facturas factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Facturas.Add(factura) != null)
                {
                    foreach (var item in factura.Detalles)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }

                    contexto.SaveChanges();
                    paso = true;
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

            return paso;
        }


        public static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Ant = BLL.FacturasBLL.Buscar(facturas.FacturaId);

                foreach (var item in Ant.Detalles)
                {
                    contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;

                    if (!facturas.Detalles.ToList().Exists(f => f.Id == item.Id))
                    {
                        //contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;
                        item.Producto = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                foreach (var item in facturas.Detalles)
                {
                    contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;

                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;

                    contexto.Entry(item).State = estado;
                    //if (facturas.Detalles.ToList().Exists(f => f.Id == item.Id))
                    //{
                    //    //item.Producto = null;
                    //    contexto.Entry(item).State = estado;
                    //    contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;

                    //}
                    //else
                    //    contexto.Detalle.Add(item);
                }

                //foreach (FacturasDetalles item in facturas.Detalles)
                //{
                //    if (item.Id == 0)
                //        contexto.Detalle.Add(item);
                //    else
                //        contexto.Entry(item).State = EntityState.Modified;
                //}

                contexto.Entry(facturas).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Facturas facturas = contexto.Facturas.Find(id);

                foreach (var item in facturas.Detalles)
                {
                    var producto = contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;
                }
                contexto.Facturas.Remove(facturas);
                contexto.SaveChanges();
                paso = true;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return paso;
        }

        public static Facturas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Facturas facturas = new Facturas();
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
            catch (Exception)
            {
                throw;
            }
            return facturas;
              
        }

        public static List<Facturas> GetList(Expression<Func<Facturas,bool>>expression)
        {
            List<Facturas> list = new List<Facturas>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Facturas.Where(expression).ToList();
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
