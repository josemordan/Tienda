using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tienda
{
    class Conexion
    {
        SqlConnection conn;
        public void conectar()
        {
            try
            {
                conn = new SqlConnection("Data Source=172.22.23.191;Initial Catalog=ButiLaFamosa;User ID=bróker;Password=broker");
                conn.Open();
                
              //  MessageBox.Show("conectado");
            }
            catch (Exception error)
            {
                MessageBox.Show("error : " + error);
            }
            
        }
        public SqlConnection retornarConn()
        {
            conn = new SqlConnection("Data Source=172.22.23.191;Initial Catalog=ButiLaFamosa;User ID=bróker;Password=broker");
            conn.Open();
            return conn;
        }
    }
}
