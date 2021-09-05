using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo
{
    public class Tienda
    {
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        private List<Prenda> prendas;
        public Tienda(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            prendas = new List<Prenda>();
        }
        public List<Prenda> GetPrendas()
        {
            return prendas;
        }
        
        public void AgregarPrenda(Prenda prenda)
        {
            prendas.Add(prenda);
        }
    }
}
