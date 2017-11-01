using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Tienda.View;
using Tienda.Model;

namespace Tienda.CRUD
{
    class CrudLogin : Conexion
    {
        string idUser;
        public string role;
        SqlCommand cmd;
        public  bool ocultar = false;
        
        public void consultarLogin(ModelLogin log)
        {
           
            if (existeUser(log.user))
            {
                if (existePass(log.pass))
                {
                    if (consultaRoll())
                    {
                        
                        Menu m = new Menu();
                        m.username = role;
                        m.evaluarUsuario(m);
                        m.Visible = true;
                        ocultar = true;
                    }
                    else
                    {
                        MessageBox.Show("Usuario no tiene roll ", "Incorrect  Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Incorrect Pass or User ", "Incorrect  Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Incorrect Pass or User ", "Incorrect  Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public Boolean existeUser(string user)
        {
            try
            {
                SqlDataReader dreader ;
                cmd = new SqlCommand("select * from usuarios where userName='" + user + "'", this.retornarConn());
                dreader =cmd.ExecuteReader();
                
                if (dreader.Read())
                {
                    idUser = dreader["id"].ToString();
                    dreader.Close();
                    return true;
                }

            }
            catch (Exception )
            {
                
            }

            return false;
        }
        public Boolean existePass(string pass)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from usuarios where passUser='" + pass + "' and id='"+idUser+"'", this.retornarConn());
                dreader = cmd.ExecuteReader();

                if (dreader.Read())
                {
                    dreader.Close();
                    return true;
                }

            }
            catch (Exception )
            {

            }
            return false;
        }
        public Boolean consultaRoll()
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from usuarios where id='"+idUser+"'", this.retornarConn());
                dreader = cmd.ExecuteReader();

                if (dreader.Read())
                {
                    role = dreader["rol"].ToString();
                    dreader.Close();
                    return true;
                }

            }
            catch (Exception )
            {

            }
            return false;
        }

         
    }
}
