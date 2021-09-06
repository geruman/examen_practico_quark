using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo
{
    class Pantalon: Prenda
    {
        public bool Chupin { get; set; }
        public Pantalon(bool chupin, bool calidadPremium, int unidadesEnStock)
        {
            idPrendaGlobal = idPrendaGlobal + 1;
            IdPrenda = idPrendaGlobal;
            Chupin = chupin;
            CalidadPremium = calidadPremium;
            UnidadesEnStock = unidadesEnStock;
        }
        public override decimal PrecioFinal()
        {
            decimal modificadorPrecio = 0;
            if (Chupin)
            {
                modificadorPrecio -= PrecioUnitario * new decimal(0.12);
            }
            if (CalidadPremium)
            {
                modificadorPrecio += PrecioUnitario * new decimal(0.3);
            }
            return PrecioUnitario + modificadorPrecio;
        }
        public override string ToString()
        {
            string descripcion = "(Pantalon";
            if (Chupin)
            {
                descripcion += " Chupin";
            }
            else
            {
                descripcion += " Normal";
            }
            if (CalidadPremium)
            {
                descripcion += " Premium)";
            }
            else
            {
                descripcion += " Standard)";
            }
            return descripcion;
        }
    }
}
