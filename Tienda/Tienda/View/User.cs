using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.CRUD;
using Tienda.Model;

namespace Tienda.View
{
    public partial class User : Form
    {
        int cont = 0;
        
        public User()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            txtUser.Text = "";
            txtPass.Text = "";
            txtConfirPass.Text = "";
            cmbRol.Text = "";
        }

        private void User_Load(object sender, EventArgs e)
        {
            txtId.Visible = false;
            label5.Visible = false;
            txtCpass.Visible = false;
            label6.Visible = false;
            txtCuser.Visible = false;
            btnAceptar.Visible = false;
            Conexion conn = new Conexion();
            conn.conectar();
            CrudUsuarios crud = new CrudUsuarios();
            crud.cargarDatos(tablaUsuarios);
            cmbRol.Items.Add("admin");
            cmbRol.Items.Add("user");
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CrudUsuarios crud = new CrudUsuarios();
            crud.cargarDatos(tablaUsuarios);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            CrudUsuarios crud = new CrudUsuarios();

            if (txtUser.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtPass.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtPass.Text.Length<6)MessageBox.Show("La clave en muy corta el tamano minimo es de 6 caracteres", "Muy corta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtConfirPass.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (cmbRol.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtPass.Text != txtConfirPass.Text) MessageBox.Show("La clave no coiside", "Discrepancia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (crud.unic.Equals(true)) MessageBox.Show("El usuario existe intente nuevamente", "Existe user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            else
            {

                label5.Visible = true;
                txtCpass.Visible = true;
                label6.Visible = true;
                txtCuser.Visible = true;
                btnAceptar.Visible = true;

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                txtPass.Visible = false;
                txtUser.Visible = false;
                txtConfirPass.Visible = false;
                cmbRol.Visible = false;
                btnActualizar.Visible = false;
                btnInsertar.Visible = false;
                btnBorrar.Visible = false;
                btnCargar.Visible = false;
                tablaUsuarios.Visible = false;
                txtBuscar.Visible = false;
                

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
         
            ModelValidar val = new ModelValidar();
            val.user = txtCuser.Text;
            val.pass = txtCpass.Text;
            CrudUsuarios crud = new CrudUsuarios();
            crud.validarPermisos(val);

            if (crud.validarPermisos(val))
            {

                cont++;
                label5.Visible = false;
                txtCpass.Visible = false;
                label6.Visible = false;
                txtCuser.Visible = false;
                btnAceptar.Visible = false;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                txtPass.Visible=true;
                txtUser.Visible = true;
                txtConfirPass.Visible = true;
                cmbRol.Visible = true;
                btnActualizar.Visible = true;
                btnInsertar.Visible = true;
                btnBorrar.Visible = true;
                btnCargar.Visible = true;
                tablaUsuarios.Visible = true;
                txtBuscar.Visible = true;
                ModelUsuarios user = new ModelUsuarios();
                user.userName = txtUser.Text;
                user.passWord = txtPass.Text;
                user.confirmPass = txtConfirPass.Text;
                user.rolUsuario = cmbRol.Text;
                CrudUsuarios crudu = new CrudUsuarios();
                crudu.insertar(user);
                crudu.cargarDatos(tablaUsuarios);
                limpiar();


            }
            else MessageBox.Show("No pos permisos", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        
        }
       
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            Menu m = new Menu();
           m.Visible=true;
        }

        public static string id;
        public static string user;
        public static string pass;
        public static string role;


        private void tablaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = tablaUsuarios.Rows[e.RowIndex].Cells["id"].Value.ToString();
                user = tablaUsuarios.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                pass = tablaUsuarios.Rows[e.RowIndex].Cells["passUser"].Value.ToString();
                role = tablaUsuarios.Rows[e.RowIndex].Cells["rol"].Value.ToString();
            }
            catch (Exception )
            {
            }
        }

        private void tablaUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (id == "")
            {
            }
            else
            {
                txtUser.Text = user;
                txtPass.Text = pass;
                cmbRol.Text = role;
                txtId.Text = id;
                btnBorrar.Enabled = true;
                btnActualizar.Enabled = true;
                btnInsertar.Enabled = false;
                btnCargar.Enabled = false;
                txtUser.Enabled = false;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(txtId.Text!="")
            {
                if (txtUser.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (txtPass.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (txtPass.Text.Length < 6) MessageBox.Show("La clave en muy corta el tamano minimo es de 6 caracteres", "Muy corta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (txtConfirPass.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (cmbRol.Text == "") MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (txtPass.Text != txtConfirPass.Text) MessageBox.Show("La clave no coiside", "Discrepancia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                else
                {

                    ModelUsuarios user = new ModelUsuarios();
                    user.idUsuarios = txtId.Text;
                    user.userName = txtUser.Text;
                    user.passWord = txtPass.Text;
                    user.rolUsuario = cmbRol.Text;
                    CrudUsuarios crud = new CrudUsuarios();
                    crud.actualizar(user);
                    btnInsertar.Enabled = true;
                    btnCargar.Enabled = true;
                    btnActualizar.Enabled = false;
                    btnBorrar.Enabled = false;
                    txtUser.Enabled = true;
                    crud.cargarDatos(tablaUsuarios);
                    limpiar();
                }
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
            ModelUsuarios user = new ModelUsuarios();
            user.idUsuarios = txtId.Text;
            CrudUsuarios crud = new CrudUsuarios();
            crud.borrar(user);
            crud.cargarDatos(tablaUsuarios);
            btnInsertar.Enabled = true;
            btnCargar.Enabled = true;
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
            txtUser.Enabled = true;
            limpiar();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            CrudUsuarios crud = new CrudUsuarios();
            crud.buscarTabla(txtBuscar.Text,tablaUsuarios);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            CrudUsuarios crud = new CrudUsuarios();
            crud.buscarTabla(txtBuscar.Text, tablaUsuarios);
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
        {
        
        }
    }
}
