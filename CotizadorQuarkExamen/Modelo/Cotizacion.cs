using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorQuarkExamen.Modelo.Exceptions;
namespace CotizadorQuarkExamen.Modelo
{
    public class Cotizacion
    {
        private static int idCotizacion = 0;
        public int IdCotizacion { get; private set; }
        public  DateTime FechaCotizacion { get; private set; }
        public int IdVendedor { get; private set; }
        public Prenda PrendaCotizada { get; private set; }
        public int CantidadDeUnidades { get; private set; }
        public decimal PrecioFinalCotizado { get; private set; }
        public Cotizacion(int idVendedor, Prenda prendaCotizada, int cantidadDeUnidades)
        {
            idCotizacion++;
            this.IdCotizacion = idCotizacion;
            FechaCotizacion = DateTime.Now;
            IdVendedor = idVendedor;
            PrendaCotizada = prendaCotizada;
            if (cantidadDeUnidades > PrendaCotizada.UnidadesEnStock)
            {
                throw new UnidadesEnStockMenoresException("La cantidad de unidades cotizadas supera a las unidades en stock.");
            }
            CantidadDeUnidades = cantidadDeUnidades;
            PrecioFinalCotizado = PrendaCotizada.PrecioFinal()*cantidadDeUnidades;
        }
    }
}
