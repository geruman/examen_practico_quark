using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Modelo
{
    class Camisa : Prenda
    {
        public bool MangaCorta { get; set; }
        public bool CuelloMao { get; set; }
        public Camisa(bool mangaCorta, bool cuelloMao,bool calidadPremium, int unidadesEnStock)
        {
            MangaCorta = mangaCorta;
            CuelloMao = cuelloMao;
            UnidadesEnStock = unidadesEnStock;
            CalidadPremium = calidadPremium;
        }
        public override decimal PrecioFinal()
        {
            decimal modificadorPrecio = 0;
            if (MangaCorta)
            {
                modificadorPrecio -= PrecioUnitario * new decimal(0.1);
            }
            if (CuelloMao)
            {
                modificadorPrecio += PrecioUnitario * new decimal(0.03);
            }
            if (CalidadPremium)
            {
                modificadorPrecio += PrecioUnitario * new decimal(0.3);
            }
            return PrecioUnitario + modificadorPrecio;
        }
        public override string ToString()
        {
            string descripcion = "(Camisa";
            if (MangaCorta)
            {
                descripcion += " Manga Corta";
            }
            else
            {
                descripcion += " Manga Larga";
            }
            if (CuelloMao)
            {
                descripcion += " Cuello Mao";
            }
            else
            {
                descripcion += " Cuello normal";
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
