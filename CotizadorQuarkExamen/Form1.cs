using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CotizadorQuarkExamen.Vista;
using CotizadorQuarkExamen.Controlador;
using CotizadorQuarkExamen.Vista.Interfaces;
namespace CotizadorQuarkExamen
{
    public partial class Form1 : Form, IMainView
    {
        private ViewController viewController;
        
        public bool BuscarCamisas()
        {
            return radioCamisa.Checked;
        }

        public Form1(ViewController viewController)
        {
            this.viewController = viewController;
            InitializeComponent();
        }

        public void UpdateTienda(string nombre, string direccion)
        {
            lblNombreTienda.Text = nombre;
            lblDireccionTienda.Text = direccion;
        }

        public void UpdateVendedor(string nombre, string apellido, int codigoVendedor)
        {
            lblVendedor.Text = "Nombre y apellido: "+nombre +" "+apellido+ " | Codigo vendedor: " + codigoVendedor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioCamisa.Checked = true;
            radioPremium.Checked = true;
            CotizandoCamisas();
            viewController.EncontrarStock();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        public void CotizandoCamisas()
        {
            checkMangaCorta.Enabled = true;
            checkMangaCorta.Checked = false;
            checkCuelloMao.Enabled = true;
            checkCuelloMao.Checked = false;
            checkChupin.Checked = false;
            checkChupin.Enabled = false;
            LimpiarDatosCotizacion();

        }

        public void CotizandoPantalones()
        {
            checkMangaCorta.Enabled = false;
            checkMangaCorta.Checked = false;
            checkCuelloMao.Enabled = false;
            checkCuelloMao.Checked = false;
            checkChupin.Checked = false;
            checkChupin.Enabled = true;
            LimpiarDatosCotizacion();
        }
        private void LimpiarDatosCotizacion()
        {
            lblPrecioCotizacion.Text = "$";
        }

        private void radioCamisa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCamisa.Checked)
            {
                CotizandoCamisas();
                viewController.EncontrarStock();
            }
            else
            {
                CotizandoPantalones();
                viewController.EncontrarStock();
            }
        }

        bool IMainView.MangaCorta()
        {
            return checkMangaCorta.Checked;
        }

        bool IMainView.CuelloMao()
        {
            return checkCuelloMao.Checked;
        }

        bool IMainView.Chupin()
        {
            return checkChupin.Checked;
        }

        bool IMainView.Premium()
        {
            return radioPremium.Checked;
        }

        void IMainView.SetUnidadesEnStock(int unidades)
        {
            lblUnidadesEnStock.Text = unidades.ToString();
        }

        private void checkMangaCorta_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarDatosCotizacion();
            viewController.EncontrarStock();
        }

        private void checkCuelloMao_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarDatosCotizacion();
            viewController.EncontrarStock();
        }

        private void radioPremium_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarDatosCotizacion();
            viewController.EncontrarStock();
        }

        private void checkChupin_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarDatosCotizacion();
            viewController.EncontrarStock();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            viewController.EsPrecioUnitarioValido(txtPrecioUnitario.Text);
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            viewController.EsCantidadDePrendasValido(txtCantidad.Text);
        }
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewController.Cotizar();
        }
        public void SetPrecioCotizacion(string precioCotizacion)
        {
            lblPrecioCotizacion.Text = precioCotizacion;
        }
        string IMainView.GetPrecioUnitario()
        {
            return txtPrecioUnitario.Text;
        }

        string IMainView.GetCantidad()
        {
            return txtCantidad.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            viewController.HistoricoCotizaciones();
        }
        public void SetHistorial(string text)
        {
            lblHistorial.Text = text;
        }
    }
}
