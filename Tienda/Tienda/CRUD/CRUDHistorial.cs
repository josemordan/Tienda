using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.View;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tienda.CRUD
{
    class CRUDHistorial : Conexion
    {
        public void consultar(DataGridView tabla)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select codigoFact, cliente, fecha, cantidad, monto, descripcion from factura  ", this.retornarConn());
                DataTable dt = new DataTable();
                da.Fill(dt);
                tabla.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Se presento un error");
            }
        }
    }
}
