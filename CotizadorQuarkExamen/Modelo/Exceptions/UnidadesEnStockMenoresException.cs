using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo.Exceptions
{
    class UnidadesEnStockMenoresException:Exception
    {
        public UnidadesEnStockMenoresException()
        {

        }
        public UnidadesEnStockMenoresException(string message):base(message)
        {
            
        }
        public UnidadesEnStockMenoresException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
