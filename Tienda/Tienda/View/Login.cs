using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.Model;
using Tienda.CRUD;

namespace Tienda.View
{
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            entrar();
        }

        public void entrar()
        {
            ModelLogin log = new ModelLogin();
            log.user = txtUser.Text;
            log.pass = txtPass.Text;
            CrudLogin crud = new CrudLogin();
            crud.consultarLogin(log);
           
            if (crud.ocultar)
            {
               
                txtUser.Text = "";
                txtPass.Text = "";
                this.Visible = false;
                
            }
             
        }
       



        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                entrar();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                entrar();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Visible = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

       

       
    }
   
}
