using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class CalculosBLL
    {
        public static Decimal CalcularGanancias(Decimal precio, Decimal costo)
        {
            return (((precio - costo) / costo) * 100);
        }

        public static Decimal CalcularPrecio(Decimal costo, Decimal ganancia)
        {
            ganancia /= 100;
            ganancia *= costo;
            return costo + ganancia;
            //return (costo * (100/(100-ganancia)));
        }

        public static Decimal CalcularImporte(Decimal cantidad, Decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubTotal(Decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(Decimal subtotal)
        {
            return subtotal * (decimal)0.18;
        }

        public static Decimal CalcularTotal(Decimal subtotal, Decimal itbis)
        {
            return subtotal + itbis;
        }

        public static Decimal CalcularDevuelta(Decimal efectivo, Decimal total)
        {
            return efectivo - total;
        }
    }
}
