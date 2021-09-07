using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorQuarkExamen.Vista;
using CotizadorQuarkExamen.Modelo;
using CotizadorQuarkExamen.Modelo.Exceptions;
using CotizadorQuarkExamen.Vista.Interfaces;
namespace CotizadorQuarkExamen.Controlador
{
    public class ViewController
    {
        public IMainView MainView { get; set; }
        private Tienda tienda;
        private Vendedor vendedor;
        Prenda prendaEncontrada = null;
        public void EncontrarStock()
        {
            prendaEncontrada = null;
            if (MainView.BuscarCamisas())
            {
                if (MainView.MangaCorta())
                {
                    if (MainView.CuelloMao())
                    {
                        foreach (Prenda prenda in tienda.GetPrendas())
                        {
                            if (prenda.GetType().Name == "Camisa")
                            {
                                Camisa c = (Camisa)prenda;
                                if (c.MangaCorta && c.CuelloMao)
                                {
                                    if (MainView.Premium())
                                    {
                                        if (c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Prenda prenda in tienda.GetPrendas())
                        {
                            if (prenda.GetType().Name == "Camisa")
                            {
                                Camisa c = (Camisa)prenda;
                                if (c.MangaCorta && !c.CuelloMao)
                                {
                                    if (MainView.Premium())
                                    {
                                        if (c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (MainView.CuelloMao())
                    {
                        foreach (Prenda prenda in tienda.GetPrendas())
                        {
                            if (prenda.GetType().Name == "Camisa")
                            {
                                Camisa c = (Camisa)prenda;
                                if (!c.MangaCorta && c.CuelloMao)
                                {
                                    if (MainView.Premium())
                                    {
                                        if (c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Prenda prenda in tienda.GetPrendas())
                        {
                            if (prenda.GetType().Name == "Camisa")
                            {
                                Camisa c = (Camisa)prenda;
                                if (!c.MangaCorta && !c.CuelloMao)
                                {
                                    if (MainView.Premium())
                                    {
                                        if (c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (MainView.Chupin())
                {
                    foreach (Prenda prenda in tienda.GetPrendas())
                    {
                        if (prenda.GetType().Name == "Pantalon")
                        {
                            Pantalon p = (Pantalon)prenda;
                            if (p.Chupin)
                            {
                                if (MainView.Premium())
                                {
                                    if (p.CalidadPremium)
                                    {
                                        prendaEncontrada = p;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (!p.CalidadPremium)
                                    {
                                        prendaEncontrada = p;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Prenda prenda in tienda.GetPrendas())
                    {
                        if (prenda.GetType().Name == "Pantalon")
                        {
                            Pantalon p = (Pantalon)prenda;
                            if (!p.Chupin)
                            {
                                if (MainView.Premium())
                                {
                                    if (p.CalidadPremium)
                                    {
                                        prendaEncontrada = p;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (!p.CalidadPremium)
                                    {
                                        prendaEncontrada = p;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }


            }
            if (prendaEncontrada != null)
            {
                MainView.SetUnidadesEnStock(prendaEncontrada.UnidadesEnStock);
            }
        }
        public bool EsPrecioUnitarioValido(string precio)
        {
            try
            {
                decimal p = decimal.Parse(precio);
                if (p > 0)
                {
                    return true;

                }
                else
                {
                    MainView.MostrarMensaje("El precio unitario debe ser mayor que cero");
                    return false;
                }
            }
            catch (FormatException)
            {
                MainView.MostrarMensaje("El precio unitario debe ser un valor númerico decimal");
                return false;
            }
        }
        public bool EsCantidadDePrendasValido(string cantidadDePrendas)
        {
            try
            {
                int i = int.Parse(cantidadDePrendas);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    MainView.MostrarMensaje("La cantidad debe ser mayor que cero.");
                    return false;
                }
            }
            catch (FormatException)
            {
                MainView.MostrarMensaje("La cantidad de prendas debe ser un número entero");
                return false;
            }

        }
        public void Cotizar()
        {
            if (EsCantidadDePrendasValido(MainView.GetCantidad()) && EsPrecioUnitarioValido(MainView.GetPrecioUnitario()) && prendaEncontrada != null)
            {
                //Se tiene que reemplazar el . por , en valores unitarios porque si no el sistema de parseo lo toma como entero, haciendo que 88.5 sea 885
                //por lo menos con mi configuracion regional
                prendaEncontrada.PrecioUnitario = decimal.Parse(MainView.GetPrecioUnitario().Replace(".", ","));
                try
                {
                    Cotizacion cot = new Cotizacion(vendedor.IdVendedor, prendaEncontrada, int.Parse(MainView.GetCantidad()));
                    vendedor.AddCotizacion(cot);
                    MainView.SetPrecioCotizacion("$ " + cot.PrecioFinalCotizado);
                }
                catch (UnidadesEnStockMenoresException ex)
                {
                    MainView.MostrarMensaje(ex.Message);
                }
            }
        }
        public void HistoricoCotizaciones()
        {
            string texto = "";
            foreach (Cotizacion c in vendedor.GetCotizaciones())
            {
                texto += $"Cotizacion {c.IdCotizacion} | Fecha {c.FechaCotizacion} | Vendedor {c.IdVendedor} |\n\t {c.PrendaCotizada.ToString()} | Unidades: {c.CantidadDeUnidades}| Total: ${c.PrecioFinalCotizado}\n\n";
            }
            MainView.SetHistorial(texto);
        }
        public Vendedor Vendedor
        {
            get
            {
                return vendedor;
            }
            set
            {
                vendedor = value;
                MainView.UpdateVendedor(vendedor.Nombre, vendedor.Apellido, vendedor.IdVendedor);
            }
        }
        public Tienda Tienda
        {
            get
            {
                return tienda;
            }
            set
            {
                tienda = value;
                MainView.UpdateTienda(Tienda.Nombre, Tienda.Direccion);
            }
        }
    }
}
