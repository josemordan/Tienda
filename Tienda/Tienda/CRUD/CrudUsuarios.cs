using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tienda.Model;
using Tienda.View;

namespace Tienda.CRUD
{
    class CrudUsuarios : Conexion
    {

        string idUser;
        public bool unic ;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public void cargarDatos(DataGridView tabla)
        {
            try
            {
                da = new SqlDataAdapter ("select * from usuarios", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                tabla.DataSource = dt;

            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        public Boolean validarPermisos(ModelValidar val)
        {
            try
            {
                if (validarUser(val.user))
                {
                    if (validarPass(val.pass))
                    {
                        
                        return true;
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("No se pueden validar los datos en estos momentos.!!!");
            }
            return false;
        }
        public Boolean validarUser(string user)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from usuarios", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    idUser = dreader["id"].ToString();
                    dreader.Close();
                    return true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }

            return false;
        }
        public Boolean validarPass(string pass)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from usuarios where passUser='" + pass + "' and id ='" + idUser + "'", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    dreader.Close();
                    return true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
            return false;
        }
        public void insertar(ModelUsuarios user)
        {
            
                try
                {

                    cmd = new SqlCommand("insert into usuarios values('" + user.userName + "','" + user.passWord + "','" + user.rolUsuario + "')", this.retornarConn());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insertado");

                }
                catch (Exception error)
                {
                    MessageBox.Show("error: " + error);
                }
           
        }
        public void unicoUser(ModelUsuarios user)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from usuarios where userName='"+user.userName+"'", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    dreader.Close();
                    unic = true; 
                }
                else
                {
                    dreader.Close();
                    unic = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }

           
        }
        public void actualizar(ModelUsuarios user)
        {
            try
            {
                cmd = new SqlCommand("update usuarios set userName='"+user.userName+"', passUser='"+user.passWord+"',rol='"+user.rolUsuario+"' where id='"+user.idUsuarios+"' ", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        public void borrar(ModelUsuarios user)
        {
            try
            {
                cmd = new SqlCommand(" delete from usuarios where id='" + user.idUsuarios + "' ", this.retornarConn());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Borrado");
            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        public void buscarTabla(string filtro, DataGridView tabla)
        {
            try
            {
                da = new SqlDataAdapter(" select * from usuarios where id like'%" + filtro + "%' or userName like'%" + filtro + "%' or passUser like'%" + filtro + "%' or rol like'%" + filtro + "%' ", this.retornarConn());
                dt = new DataTable();
                da.Fill(dt);
                tabla.DataSource = dt;

            }
            catch (Exception error)
            {
                MessageBox.Show("error: " + error);
            }
        }
        
    }
}
