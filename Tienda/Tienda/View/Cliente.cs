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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CrudCliente crud= new CrudCliente();
            crud.consultar(tablaCliente);
        }
        public void limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            btnInsertar.Enabled = true;
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios","Campos nulos", MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            else if (txtApellido.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtCedula.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ModelCliente clientes = new ModelCliente();
                clientes.nombre = txtNombre.Text;
                clientes.apellido = txtApellido.Text;
                clientes.cedula = txtCedula.Text;
                clientes.direccion = txtDireccion.Text;
                CrudCliente crud = new CrudCliente();
                crud.insertar(clientes);
                crud.consultar(tablaCliente);
                limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
             if (txtNombre.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios","Campos nulos", MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            else if (txtApellido.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtCedula.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
             else if (txtDireccion.Text == "")
             {
                 MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
             }
             else
             {
                 ModelCliente clientes = new ModelCliente();
                 clientes.id = Convert.ToInt16(txtId.Text);
                 clientes.nombre = txtNombre.Text;
                 clientes.apellido = txtApellido.Text;
                 clientes.cedula = txtCedula.Text;
                 clientes.direccion = txtDireccion.Text;
                 CrudCliente crud = new CrudCliente();
                 crud.actualizar(clientes);
                 crud.consultar(tablaCliente);
                 limpiar();
             }
        }
        

        public static string id;
        public static string nombre;
        public static string apellido;
        public static string cedula;
        public static string direccion;
       
        private void tablaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = tablaCliente.Rows[e.RowIndex].Cells["id"].Value.ToString();
                nombre = tablaCliente.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                apellido = tablaCliente.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                cedula = tablaCliente.Rows[e.RowIndex].Cells["cedula"].Value.ToString();
                direccion = tablaCliente.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
            }
            catch (Exception)
            {
             //   MessageBox.Show("error");
            }
        }

        private void tablaCliente_DoubleClick(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("seleccione una fila para editar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtId.Text = id;
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtCedula.Text = cedula;
                txtDireccion.Text = direccion;
                btnInsertar.Enabled = false;
                btnActualizar.Enabled = true;
                btnBorrar.Enabled = true;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ModelCliente cliente = new ModelCliente();
            cliente.id = Convert.ToInt16(txtId.Text);
            CrudCliente crud = new CrudCliente();
            crud.borrar(cliente);
            crud.consultar(tablaCliente);
            limpiar();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar en la tabla")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar en la tabla";
                txtBuscar.ForeColor = Color.Blue;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            CrudCliente crud = new CrudCliente();
            crud.buscarTXT(tablaCliente,txtBuscar.Text);
        }

        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

    }
}
