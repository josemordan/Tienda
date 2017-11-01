using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tienda.Model;

namespace Tienda.CRUD
{
    class CRUDProducto : Conexion
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public void insertar(ModelProductos prod)
        {
            try
            {
                cmd = new SqlCommand("insert into producto values ('" + prod.descripcion + "', '" + prod.precio + "', '" + prod.estado + "')", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente");
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void cargar(DataGridView tabla)
        {
            try
            {
              //  SqlDataReader dreader;
                da = new SqlDataAdapter("select * from producto", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                tabla.DataSource = dt;
            }
            catch(Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
        public void actualizar(ModelProductos prod)
        {
            try
            {
                cmd = new SqlCommand("update producto set descripcion='" + prod.descripcion + "', precio='" + prod.precio + "', estado='" + prod.estado + "' where id=" + prod.id + " ", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        public void borrar(ModelProductos prod)
        {
            try
            {
                cmd = new SqlCommand("delete from producto where id=" + prod.id + "", this.retornarConn());
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        public void buscarTxt(DataGridView tabla, string filtro)
        {
            try
            {
               
                da = new SqlDataAdapter("select * from producto where descripcion like'%" + filtro + "%' or precio like'%" + filtro + "%' or estado like'%" + filtro + "%'", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                tabla.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error);
            }
        }
    }
}
