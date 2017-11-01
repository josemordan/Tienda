using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Tienda.Model;

namespace Tienda.CRUD
{
    class CrudCliente :Conexion
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public void consultar(DataGridView table)
        {
            try
            {
                da = new SqlDataAdapter("select * from cliente", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource=dt;
            }
            catch (Exception )
            {
                MessageBox.Show("No se puede consultar");
            }
        }
        public void insertar(ModelCliente cliente)
        {
            try
            {
                cmd = new SqlCommand("insert into cliente values ('"+cliente.nombre+"', '"+cliente.apellido+"','"+cliente.cedula+"','"+cliente.direccion+"')", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente");
            }
            catch (Exception )
            {
                MessageBox.Show("No se puede insertar");
            }
        }
        public void actualizar(ModelCliente cliente)
        {
            try
            {
                cmd = new SqlCommand("update cliente set nombre='"+cliente.nombre+"', apellido='"+cliente.apellido+"', cedula='"+cliente.cedula+"', direccion='"+cliente.direccion+"' where id="+cliente.id+"",this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("actualizado correctamente");
            }
            catch (Exception )
            {
                MessageBox.Show("no se pudo actualizar");
            }
        }
        public void borrar(ModelCliente cliente)
        {
            try
            {
                cmd = new SqlCommand("delete from cliente where id="+cliente.id+"", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("borrado correctamente");
            }
            catch (Exception )
            {
                MessageBox.Show("No se puedo borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void buscarTXT(DataGridView table, string buscar)
        {
            try
            {
                da = new SqlDataAdapter("select * from  cliente where nombre like'%"+buscar+"%' or apellido like '%"+buscar+"%' or cedula like '%"+buscar+"%' or direccion like '%"+buscar+"%'",this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource =dt;
                
            }
            catch (Exception )
            {
                MessageBox.Show("error");
            }
        }
    }
}
