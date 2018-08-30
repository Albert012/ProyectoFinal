using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class InventariosBLL
    {

        public static bool Guardar(Inventarios inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
                
            try
            {
                if(contexto.Inventarios.Add(inventario) != null)
                {
                    contexto.Productos.Find(inventario.ProductoId).Inventario += inventario.Cantidad;                   
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

        public static bool Modificar(Inventarios inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Inventarios> repositorio = new Repositorio<Inventarios>();
            try
            {
                contexto.Entry(inventario).State = EntityState.Modified;

                Inventarios ant = repositorio.Buscar(inventario.InventarioId);
                var Producto = contexto.Productos.Find(inventario.ProductoId);
                var ProductoAnt = contexto.Productos.Find(ant.ProductoId);

                if(inventario.ProductoId != ant.ProductoId)
                {
                    Producto.Inventario += inventario.Cantidad;
                    ProductoAnt.Inventario -= ant.Cantidad;
                }
                {
                    int diferencia = inventario.Cantidad - ant.Cantidad;
                    Producto.Inventario += diferencia;
                }

                
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                Inventarios inventarios = contexto.Inventarios.Find(id);
                contexto.Productos.Find(inventarios.ProductoId).Inventario += inventarios.Cantidad;

                contexto.Inventarios.Remove(inventarios);
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
        
    }
}
