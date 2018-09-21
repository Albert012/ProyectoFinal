using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemsOfSalesWeb.Utilitarios
{
    public class Utils
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static decimal ToDecimal(string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }
    }
}