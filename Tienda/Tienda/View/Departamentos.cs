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

namespace Tienda
{
    public partial class Departamentos : Form
    {
        public Departamentos()
        {
            InitializeComponent();
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            con.conectar();
            txtEstado.Items.Add("Activo");
            txtEstado.Items.Add("Inactivo");
            
        }
        public void limpiar()
        {
            txtDescripcion.Text = "";
            txtEstado.Text = "";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CrudDepart crud = new CrudDepart();
            crud.consultar(table);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text=="")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            else if (txtEstado.Text == "")
            {
                 MessageBox.Show("Seleccione un estado", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                      
            
            else
            {
                
                Departamento dep = new Departamento();
                dep.Descripcion = txtDescripcion.Text;
                dep.Estado = txtEstado.Text;
                CrudDepart crud = new CrudDepart();
                crud.insert(dep);
                crud.consultar(table);
                limpiar();
            }
           
            
        }

        
        public static string id;
        public static string decripcion;
        public static string estado;
        public static string i;

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                id = table.Rows[e.RowIndex].Cells["id"].Value.ToString();
                decripcion = table.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                estado = table.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            }
            catch (Exception )
            {
              //  MessageBox.Show("Asegurese de selecionar solo una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void table_DoubleClick(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("seleccione una fila para editar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                limpiar();
                txtId.Text = id;
                txtDescripcion.Text = decripcion;
                txtEstado.Text = estado;
                btnInsert.Enabled = false;
                btnActualizar.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Departamento dep = new Departamento();
            if (txtId.Text != "")
            {
                dep.Id = Convert.ToInt16(txtId.Text);
                CrudDepart crud = new CrudDepart();
                crud.borrar(dep);
                crud.consultar(table);
                limpiar();
            }
            else
            {
                MessageBox.Show("no hay datos a borrar");
            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Favor llenar los campos vacios", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtEstado.Text == "")
            {
                MessageBox.Show("Seleccione un estado", "Campos nullos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Departamento dep = new Departamento();
                dep.Id = Convert.ToInt16(txtId.Text);
                dep.Descripcion = txtDescripcion.Text;
                dep.Estado = txtEstado.Text;
                CrudDepart crud = new CrudDepart();
                crud.modificar(dep);
                btnInsert.Enabled = true;
                crud.consultar(table);
                limpiar();
            }
            
        }

        
        

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
            CrudDepart crud = new CrudDepart();
            crud.buscarTxt(txtBuscar.Text, table);
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
                txtBuscar.ForeColor = Color.Silver;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Departamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        
       
        

        
        

        
        
        
    }
}
