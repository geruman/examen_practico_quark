using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo
{
    public class Vendedor
    {
        public int IdVendedor { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        private List<Cotizacion> cotizaciones;
        public Vendedor(int idVendedor, string nombre, string apellido)
        {
            IdVendedor = idVendedor;
            Nombre = nombre;
            Apellido = apellido;
            cotizaciones = new List<Cotizacion>();
        }
        public void AddCotizacion(Cotizacion cotizacion)
        {
            cotizaciones.Add(cotizacion);
        }
        public List<Cotizacion> GetCotizaciones()
        {
            return cotizaciones;
        }

    }
}
