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
            lblVendedor.Text = nombre +" "+apellido+ " | " + codigoVendedor;
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
            
        }

        public void CotizandoPantalones()
        {
            checkMangaCorta.Enabled = false;
            checkMangaCorta.Checked = false;
            checkCuelloMao.Enabled = false;
            checkCuelloMao.Checked = false;
            checkChupin.Checked = false;
            checkChupin.Enabled = true;
        }

        private void radioCamisa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCamisa.Checked)
            {
                CotizandoCamisas();
            }
            else
            {
                CotizandoPantalones();
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
            viewController.EncontrarStock();
        }

        private void checkCuelloMao_CheckedChanged(object sender, EventArgs e)
        {
            viewController.EncontrarStock();
        }

        private void radioPremium_CheckedChanged(object sender, EventArgs e)
        {
            viewController.EncontrarStock();
        }
    }
}
