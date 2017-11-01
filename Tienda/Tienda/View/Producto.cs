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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            txtDescripcion.Text = "";
            txtId.Text = "";
            txtPrecio.Text = "";
            cmbEstado.Text = "";
            btnInsertar.Enabled = true;
            btnCargar.Enabled = true;
            btnActualizar.Enabled = false;
            btnBorrar.Enabled = false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtPrecio.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (cmbEstado.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                ModelProductos prod = new ModelProductos();
                prod.descripcion = txtDescripcion.Text;
                prod.estado = cmbEstado.Text;
                prod.precio = txtPrecio.Text;
                CRUDProducto crud = new CRUDProducto();
                crud.insertar(prod);
                limpiar();
                crud.cargar(tablaProductos);
            }
        }

        private void Producto_Load(object sender, EventArgs e)
        {

            cmbEstado.Items.Add("Nuevo");
            cmbEstado.Items.Add("Usado");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CRUDProducto prod = new CRUDProducto();
            prod.cargar(tablaProductos);
        }

        public static string id;
        public static string descripcion;
        public static string estado;
        public static string precio;

        private void tablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = tablaProductos.Rows[e.RowIndex].Cells["id"].Value.ToString();
            descripcion = tablaProductos.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
            estado = tablaProductos.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            precio = tablaProductos.Rows[e.RowIndex].Cells["precio"].Value.ToString();
        }

        private void tablaProductos_DoubleClick(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("selecciones una fila");
            }
            else
            {
                txtId.Text = id;
                txtDescripcion.Text = descripcion;
                txtPrecio.Text = precio;
                cmbEstado.Text = estado;
                btnActualizar.Enabled = true;
                btnBorrar.Enabled = true;
                btnCargar.Enabled = false;
                btnInsertar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ModelProductos prod = new ModelProductos();
            prod.id = Convert.ToInt16(txtId.Text);
            prod.descripcion = txtDescripcion.Text;
            prod.precio = txtPrecio.Text;
            prod.estado = cmbEstado.Text;
            CRUDProducto crud = new CRUDProducto();
            crud.actualizar(prod);
            limpiar();
            crud.cargar(tablaProductos);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ModelProductos prod = new ModelProductos();
            prod.id = Convert.ToInt16(txtId.Text);
            CRUDProducto crud = new CRUDProducto();
            crud.borrar(prod);
            limpiar();
            crud.cargar(tablaProductos);
        }


        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar en tabla")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Buscar en tabla";
                txtBuscar.ForeColor = Color.Blue;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            CRUDProducto crud = new CRUDProducto();
            crud.buscarTxt(tablaProductos, txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            CRUDProducto crud = new CRUDProducto();
            crud.buscarTxt(tablaProductos, txtBuscar.Text);
        }

        private void tablaProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void Producto_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
