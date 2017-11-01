using System;
using System.Collections;
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
    public partial class Factura : Form
    {
        DataTable dt = new DataTable();
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            txtDate.Enabled = false;
            timer1.Enabled = true;
            btnImprimir.Enabled = false;
            txtMonto.Enabled = false;
            CrudFactura crud = new CrudFactura();
            crud.cargarCliente(cmbCliente);
            crud.cargarArticulo(txtArticulo);
            dt.Columns.Add("Cliente");
            dt.Columns.Add("Articulo");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Monto");
            for(int i= 1; i<=20;i++){
                cmbCantidad.Items.Add(""+i+"");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string[] productos = new string[tabalFactura.RowCount];
            string cliente = "- ";
            
            string monto = "- ";
            string cantidad = "- ";
            ModelFactura fact = new ModelFactura();
            if (cmbCliente.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (txtArticulo.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (cmbCantidad.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (txtMonto.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            else
            {
                
                for (int i = 0; i < tabalFactura.RowCount; i++)
                {
                    cliente =  tabalFactura.Rows[i].Cells["Cliente"].Value.ToString();
                    productos[i] =  tabalFactura.Rows[i].Cells["Articulo"].Value.ToString();
                    monto =  tabalFactura.Rows[i].Cells["Monto"].Value.ToString();
                    cantidad = tabalFactura.Rows[i].Cells["cantidad"].Value.ToString();
                }


                fact.cliente = cliente;
                
                fact.monto = monto;
                fact.cantidad = cantidad;
                fact.fecha = txtDate.Text;
                fact.producto = productos;
                
               
                CrudFactura crud = new CrudFactura();
                crud.imprimir(fact);
                txtArticulo.Text = "";
                txtMonto.Text = "";
                cmbCantidad.Text = "";
                cmbCliente.Text = "";
                btnImprimir.Enabled = false;
                tabalFactura.DataSource = null;
                cmbCliente.Enabled = true;


                
            }
            

             
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (cmbCliente.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (txtArticulo.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (cmbCantidad.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            if (txtMonto.Text == "")
            {
                MessageBox.Show("verifique los campos vacios");
            }
            else
            {

                try
                {
                    DataRow row = dt.NewRow();
                    row["Cliente"] = cmbCliente.Text;
                    row["Articulo"] = txtArticulo.Text;
                    row["cantidad"] = cmbCantidad.Text;
                    row["Monto"] = Convert.ToInt16(txtMonto.Text) * Convert.ToInt16(cmbCantidad.Text);
                    dt.Rows.Add(row);
                    tabalFactura.DataSource = dt;
                    tabalFactura.Update();
                    btnImprimir.Enabled = true;
                    cmbCliente.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("error " + error);
                }
            }
            
        }

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CrudFactura crud = new CrudFactura();
                crud.caragarMonto(txtMonto, txtArticulo.Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabalFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Factura_FormClosing(object sender, FormClosingEventArgs e)
        {
       
        }
    }
}
