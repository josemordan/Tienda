using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.View;
using Tienda.Model;
using Tienda.CRUD;

namespace Tienda
{
    public partial class Menu : Form
    {
        
        public string username { get; set; }

        public Menu()
        {
            InitializeComponent();

        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Departamentos f = new Departamentos();
            f.Visible = true;
           
           
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados emp = new Empleados();
            emp.Visible = true;
        }

        private void sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Visible = true;
        }

       

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura f = new Factura();
            f.Visible = true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
           
        }

        public void evaluarUsuario(Menu menu) 
        { 
            if(!menu.username.Equals("admin"))
            {
                bloquearMenu();
            }
        }

        private void bloquearMenu() 
        {
            menuToolStripMenuItem.Enabled = false;
        }

        private void sToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Visible = true;
        }

        private void registrarUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Visible = true;
     
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ventas v = new Ventas();
            v.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
           
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
