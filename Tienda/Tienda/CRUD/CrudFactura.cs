using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

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

        /**
         * Este metodo Guarda en la tabla factura y guarda el archivo en la carpeta PDF
         * 
         * */
        public void imprimir(ModelFactura fact)
        {
            try
            {
                generarIdFact();
               
                /*
                 * bucle-for para insertar en la base de datos   
                 * 
                 * */
                for (int i = 0; i < fact.producto.Length; i++)
                {
                    cmd = new SqlCommand("insert into factura values('" + fact.cliente + "', '" + fact.fecha + "' "
                    + ", '" + fact.cantidad[i] + "', '" + fact.monto[i] + "', '" + fact.producto[i] + "', " + codFact + ")", this.retornarConn());
                    cmd.ExecuteNonQuery();
                }
                /*
                 * generar direccion del archivo 
                 * */
                if (!Directory.Exists(@"C:\Users\JMordan\Documents\Visual Studio 2012\Projects\Tienda\PDF"))
                {
                    Directory.CreateDirectory(@"C:\Users\JMordan\Documents\Visual Studio 2012\Projects\Tienda\PDF");
                }
                /*
                 * escribir el archivo 
                 * 
                 * */
                TextWriter sw = new StreamWriter(@"C:\Users\JMordan\Documents\Visual Studio 2012\Projects\Tienda\PDF\Factura #"+codFact+".txt");
              
                sw.WriteLine("                       Buti La Famosa " + "\t");
                sw.WriteLine(

                "                   Cliente:   " +fact.cliente + "\t");
                sw.WriteLine("   " + "\t");
                sw.WriteLine("                 Fecha: " + fact.fecha + "\t");
                
                sw.WriteLine("                         Cogigo fact:"+codFact + "\t");
                sw.WriteLine("   " + "\t");
                sw.WriteLine("cantidad   " + "Precio       " + " Producto                          " + "Total");
                sw.WriteLine("   " + "\t");
                long total = 0;
                for (int i = 0; i < fact.producto.Length ; i++)
                {
                    sw.WriteLine(  fact.cantidad[i]+ "\t"
                                 + "   " + (Convert.ToInt64(fact.monto[i]) / Convert.ToInt64( fact.cantidad[i])) + "\t"
                                 + "   " + fact.producto[i] + "\t"
                                 + "   " + fact.monto[i] +"\t");
                    total = total + Convert.ToInt64(fact.monto[i]);
                }
                sw.WriteLine("  " + "\t");
                sw.WriteLine("                                                    Total: " +total + "\t");
                sw.Close();
                
                MessageBox.Show("Imprimido" ); 

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
                cmd = new SqlCommand("select max(codigoFact) as 'codigoFact' from factura", this.retornarConn());
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    
                        codFact = Convert.ToInt32(dreader["codigoFact"].ToString());
                      
                        codFact = codFact + 3;
                       
                    
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
