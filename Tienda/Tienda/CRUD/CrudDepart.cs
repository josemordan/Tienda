using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tienda.Model;

namespace Tienda
{
    class CrudDepart : Conexion
    {
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        

        public void consultar(DataGridView table)
        {
            try
            {
                da = new SqlDataAdapter("select * from  departamento", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource = dt;
               
            }
            catch (Exception error)
            {
                MessageBox.Show("error " + error);
            }
        }
        public void insert(Departamento dep)
        {
            try
            {
                cmd = new SqlCommand("insert into  departamento values('" + dep.Descripcion + "','" + dep.Estado + "')", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Departamento insertado");
            }
            catch (Exception error)
            {
                MessageBox.Show("ocurio un error: " + error);
            }
            
        }
        public void modificar(Departamento dep)
        {
            try
            {
                cmd = new SqlCommand("update departamento set descripcion='"+dep.Descripcion+"', estado ='"+dep.Estado+"' where id ="+dep.Id+"", this.retornarConn() );
                cmd.ExecuteNonQuery();
                MessageBox.Show("departamento modificado");
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error: " + error);

            }
        }
        public void borrar(Departamento dep)
        {
            try
            {
                cmd = new SqlCommand("delete from departamento   where id =" + dep.Id + "", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("departamento borrado");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error: " + error);

            }
        }
        public void buscarTxt(string buscar, DataGridView table)
        {
            try
            {
                da = new SqlDataAdapter("select * from departamento where descripcion like '%" + buscar + "%'", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error: " + error);
            }
        }

    }
}
