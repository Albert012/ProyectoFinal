using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PagosBLL
    {
        public static bool Guardar(Pagos pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Pagos.Add(pago) != null)
                {
                    contexto.Clientes.Find(pago.ClienteId).Balance -= pago.Total;
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

        public static bool Modificar(Pagos pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Pagos> repositorio = new Repositorio<Pagos>();
            try
            {
                contexto.Entry(pago).State = EntityState.Modified;

                Pagos ant = repositorio.Buscar(pago.PagoId);
                var Cliente = contexto.Clientes.Find(pago.ClienteId);
                var ClienteAnt = contexto.Clientes.Find(ant.ClienteId);

                if (pago.ClienteId != ant.ClienteId)
                {
                    Cliente.Balance -= pago.Total;
                    ClienteAnt.Balance += ant.Total;
                }
                else
                {
                    decimal diferencia = pago.Total - ant.Total;
                    Cliente.Balance -= diferencia;
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

    }
}
