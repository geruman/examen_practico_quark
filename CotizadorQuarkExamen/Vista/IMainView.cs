using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorQuarkExamen.Vista
{
    public interface IMainView
    {
        
        void UpdateTienda(string nombre, string direccion);
        void UpdateVendedor(string nombre, string apellido, int codigoVendedor);
        void CotizandoCamisas();
        void CotizandoPantalones();
        bool BuscarCamisas();
        bool MangaCorta();
        bool CuelloMao();
        bool Chupin();
        bool Premium();
        void SetUnidadesEnStock(int unidades);
        void MostrarMensaje(string mensaje);
        string GetPrecioUnitario();
        string GetCantidad();
        void SetPrecioCotizacion(string precioCotizacion);
        void SetHistorial(string texto);
    }
}
