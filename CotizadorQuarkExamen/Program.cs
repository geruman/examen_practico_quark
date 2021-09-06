using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CotizadorQuarkExamen.Controlador;
using CotizadorQuarkExamen.Modelo;
namespace CotizadorQuarkExamen
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            Tienda tienda = new Tienda("La Megatienda de Prendas", "Calle SiempreViva 3322");
            Vendedor vendedor = new Vendedor(1, "Jorge \"Demo\"", "Padillas");
            tienda.AgregarVendedor(vendedor);
            //Camisas
            //100 de manga corta, cuello mao y calidad estandar
            tienda.AgregarPrenda(new Camisa(true, true, true, 100));
            //100 de manga corta, cuello mao y calidad premium
            tienda.AgregarPrenda(new Camisa(true, true, false, 100));
            //150 de manga corta, cuello normal y calidad estandar
            tienda.AgregarPrenda(new Camisa(true, false, false, 150));
            //150 de manga corta, cuello normal y calidad premium
            tienda.AgregarPrenda(new Camisa(true, false, true, 150));
            //75 de manga larga, cuello mao y calidad premium
            tienda.AgregarPrenda(new Camisa(false, true, true, 75));
            //75 de manga larga cuello mao y calidad estandar
            tienda.AgregarPrenda(new Camisa(false, true, false, 75));
            //175 de manga larga, cuello normal y calidad premium
            tienda.AgregarPrenda(new Camisa(false, false, true, 175));
            //175 de manga larga, cuello normal y calidad estandar
            tienda.AgregarPrenda(new Camisa(false, false, false, 175));

            //pantalones
            //750 chupines de calidad estandar
            tienda.AgregarPrenda(new Pantalon(true, false, 750));
            //750 chupines de calidad premium
            tienda.AgregarPrenda(new Pantalon(true, true, 750));
            //250 comunes de calidad estandar
            tienda.AgregarPrenda(new Pantalon(false, false, 250));
            //250 comunes de calidad premium
            tienda.AgregarPrenda(new Pantalon(false, true, 250));

            ViewController viewController = new ViewController();
            Form1 form1 = new Form1(viewController);
            viewController.MainView = form1;
            viewController.Tienda = tienda;
            viewController.Vendedor = vendedor;
            
            Application.Run(form1);
        }
    }
}
