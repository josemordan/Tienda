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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }
        public Boolean validarCorreo()
        {
            string correo = txtCorreo.Text;
            int arroba = 0;
            int posicion = 0;
            for (int i = 0; i < correo.Length; i++)
            {
                
                if (correo[i] == '@')
                {
                    arroba++;
                    posicion = i;
                }
            }
            if (arroba > 1 || arroba < 1)
            {
                return false;
            }
            else
            {
                if (correo.Substring(posicion) == "@hotmail.com")
                {
                    return true;
                }
                else if (correo.Substring(posicion) == "@hotmail.es")
                {
                    return true;
                }
                else if (correo.Substring(posicion) == "@gmail.com")
                {
                    return true;
                }
                else if (correo.Substring(posicion) == "@outlook.com")
                {
                    return true;
                }
                else if (correo.Substring(posicion) == "@outlook.es")
                {
                    return true;
                }
                else if (correo.Substring(posicion) == "@banreservas.com")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Correo invalido tome en cuenta los dominios permitidos: \n hotmail.es \n hotmail.com \n outlook.es \n outlook.com");
                    return false;
                }
                
            }
            
            //return false;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtApellido.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCedula.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEdad.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTelefono.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCorreo.Text == "")
            {
                MessageBox.Show("Por favor llenar los campos vacios", "Campos nulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (validarCorreo())
                {
                    ModelEmpleado emp = new ModelEmpleado();
                    emp.nombre = txtNombre.Text;
                    emp.apellido = txtApellido.Text;
                    emp.cedula = txtCedula.Text;
                    emp.direccion = txtDireccion.Text;
                    emp.edad = Convert.ToInt16(txtEdad.Text);
                    emp.telefono = txtTelefono.Text;
                    emp.correo = txtCorreo.Text;
                    CrudEmpleado crud = new CrudEmpleado();
                    crud.insertar(emp);
                    crud.consultar(tablaEmpleados);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("correo invalido");
                }
            }
            
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            Conexion conn = new Conexion();
            conn.conectar();
        }
        void limpiar()
        {
            txtNombre.Text ="";
            txtApellido.Text= "";
            txtCedula.Text="";
            txtDireccion.Text="";
            txtEdad.Text="";
            txtTelefono.Text="";
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CrudEmpleado crud = new CrudEmpleado();
            crud.consultar(tablaEmpleados);
        }
        public static string id;
        public static string nombre;
        public static string apellidp;
        public static string cedula;
        public static string direccion;
        public static string edad;
        public static string telefono;
        public static string correo;




        private void tablaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = tablaEmpleados.Rows[e.RowIndex].Cells["id"].Value.ToString();
                nombre = tablaEmpleados.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                apellidp = tablaEmpleados.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                cedula = tablaEmpleados.Rows[e.RowIndex].Cells["cedula"].Value.ToString();
                direccion = tablaEmpleados.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                edad = tablaEmpleados.Rows[e.RowIndex].Cells["edad"].Value.ToString();
                telefono = tablaEmpleados.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                correo = tablaEmpleados.Rows[e.RowIndex].Cells["correo"].Value.ToString();

            }
            catch (Exception )
            {
                //MessageBox.Show("por favor selecione una fila ");
            }
            
        }

        private void tablaEmpleados_DoubleClick(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("asegurese de seleccionar una fila", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtId.Text = id;
                txtNombre.Text = nombre;
                txtApellido.Text = apellidp;
                txtCedula.Text = cedula;
                txtDireccion.Text = direccion;
                txtEdad.Text = edad;
                txtTelefono.Text = telefono;
                txtCorreo.Text = correo;
                btnActualizar.Enabled = true;
                btnBorrar.Enabled = true;
                btnInsertar.Enabled = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            ModelEmpleado emp = new ModelEmpleado();
            emp.id = Convert.ToInt16(txtId.Text);
            emp.nombre = txtNombre.Text;
            emp.apellido = txtApellido.Text;
            emp.cedula = txtCedula.Text;
            emp.direccion = txtDireccion.Text;
            emp.edad = Convert.ToInt16(txtEdad.Text);
            emp.telefono = txtTelefono.Text;
            CrudEmpleado crud = new CrudEmpleado();
            crud.Modificar(emp);
            crud.consultar(tablaEmpleados);
            limpiar();
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
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

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar en la tabla")
            {
                txtBuscar.Text = "";

                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            
            CrudEmpleado crud = new CrudEmpleado();
            crud.buscarTxt(txtBuscar.Text, tablaEmpleados);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                ModelEmpleado emp = new ModelEmpleado();
                emp.id = Convert.ToInt16(txtId.Text);
                CrudEmpleado crud = new CrudEmpleado();
                crud.borrar(emp);
                crud.consultar(tablaEmpleados);

                limpiar();
            }
            else
            {
                MessageBox.Show("No hay datos a borrar");
            }
            
        }

        private void Empleados_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

           
    }
}
