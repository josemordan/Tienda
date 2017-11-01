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
    class CrudEmpleado : Conexion
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public void insertar(ModelEmpleado emp)
        {
            try
            {
                cmd = new SqlCommand("insert into empleados values('" + emp.nombre + "','" + emp.apellido + "','" + emp.cedula + "','" + emp.direccion + "'," + emp.edad + ",'" + emp.telefono + "','"+emp.correo+"')", this.retornarConn());
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ah ocurido un error mientras se intentaba insetar" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void consultar(DataGridView table)
        {
            try
            {
                da = new SqlDataAdapter("select * from empleados", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource = dt;
            }
            catch (Exception )
            {
                MessageBox.Show("Ha ocurrido un error", "consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modificar(ModelEmpleado emp)
        {
            try
            {
                cmd = new SqlCommand("update empleados set nombre='"+emp.nombre+"', apellido='"+emp.apellido+"', cedula='"+emp.cedula+"',direccion='"+emp.direccion+"',edad="+emp.edad+",telefono='"+emp.telefono+"', correo ='"+emp.correo+"' where id="+emp.id+"",this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha modificado correctamente ","Modificacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch(Exception )
            {
               MessageBox.Show("","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void buscarTxt(string buscar, DataGridView table)
        {
            try
            {
                da = new SqlDataAdapter("select * from empleados where nombre like '%" + buscar + "%' or " +
                    " apellido like '%" + buscar + "%' or cedula like '%" + buscar + "%' or " +
                    "direccion like '%" + buscar + "%' or edad like '%" + buscar + "%' or telefono like '%" + buscar + "%' or correo like '%"+buscar+"' ", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                table.DataSource = dt;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ah ocurrido un error: " + error);
            }
        }
        public void borrar(ModelEmpleado emp)
        {
            try
            {
                cmd = new SqlCommand("delete from empleados where id='" + emp.id + "'", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Borrado corractamente", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error " + e);
            }

        }

    }
}
