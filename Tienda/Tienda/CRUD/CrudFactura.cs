using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Tienda.CRUD
{
    class CrudFactura : Conexion
    {
        SqlCommand cmd;
        
        int codFact;


        public void cargarCliente(ComboBox cmbCliente)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from cliente", this.retornarConn());
                dreader = cmd.ExecuteReader();
                while (dreader.Read())
                {
                    cmbCliente.Items.Add(dreader["Nombre"].ToString());
                }
                dreader.Close();
            }
            catch (Exception )
            {
            }
        }
        public void cargarArticulo(TextBox txtArticulo)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from producto", this.retornarConn());
                dreader = cmd.ExecuteReader();
                while(dreader.Read())
                {
                    txtArticulo.AutoCompleteCustomSource.Add(dreader["descripcion"].ToString());
                    //txtArticulo.Text = dreader["descripcion"].ToString();
                }
                dreader.Close();
            }
            catch (Exception )
            {
            }
        }
        public void caragarMonto(TextBox txtMonto, string producto)
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select precio from producto where descripcion ='" + producto + "'", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    txtMonto.Text = dreader["precio"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("error" + error);
            }
        }
        public void imprimir(ModelFactura fact)
        {
            try
            {
                generarIdFact();   
                foreach (string elemento in fact.producto)
                {
                
                
                cmd = new SqlCommand("insert into factura values('"+fact.cliente+"', '"+fact.fecha+"' "
                +", '"+fact.cantidad+"', '"+fact.monto+"', '"+elemento+"', "+codFact+")", this.retornarConn());
                cmd.ExecuteNonQuery();
                }

                MessageBox.Show("imprimido " ); 

            }
            catch (Exception error)
            {
                MessageBox.Show("Error " + error); 
            }
        }
        public void generarIdFact()
        {
            try
            {
                SqlDataReader dreader;
                cmd = new SqlCommand("select * from factura", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    codFact = Convert.ToInt32(dreader["codigoFact"].ToString());
                    MessageBox.Show(codFact+"");
                    codFact = codFact + 3;
                    MessageBox.Show(codFact + "");

                }
                else
                {
                    Random ram = new Random();
                    codFact = Convert.ToInt32(ram.Next(155,255));

                }
                dreader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error + " all");
            }
        }
       
        }

}
