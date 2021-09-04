using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CotizadorQuarkExamen.Vista;
using CotizadorQuarkExamen.Modelo;
namespace CotizadorQuarkExamen.Controlador
{
    public class ViewController
    {
        public IMainView MainView { get; set; }
        private Tienda tienda;
        private Vendedor vendedor;
        public void EncontrarStock()
        {
            if (MainView.BuscarCamisas())
            {
                Prenda prendaEncontrada=null;
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
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
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
                                        }
                                    }
                                    else
                                    {
                                        if (!c.CalidadPremium)
                                        {
                                            prendaEncontrada = c;
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
                if (prendaEncontrada!=null)
                {
                    MainView.SetUnidadesEnStock(prendaEncontrada.UnidadesEnStock);
                }

            }
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
