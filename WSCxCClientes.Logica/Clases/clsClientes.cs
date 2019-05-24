using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WSCxCClientes.Logica.Clases;

namespace WSCxCClientes.Logica.Clases
{

    public class ConsultaFactura
    {
        SqlCommand sqlCommand = null;
        SqlConnection SqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter SqlDataAdapter = null;

        string stConexion;

        public ConsultaFactura()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        public SqlCommand SqlCommand { get; private set; }

        public ConsultaFactura EstadoCartera(int intIdTienda, string strPassword, string strId_Cliente, string strclave_cliente, List<Factura> facFacturas, string strNombre_Cliente, string strApellidos_Cliente, string strEmail, string strTelefono, string strCampo1, string strCampo2, string strCampo3, string cod_servicio_principal, string es_multicredito, string strError) ////Obligatorio - Identificación Cliente

        {
            try
            {
                SqlConnection = new SqlConnection(stConexion);
                SqlConnection.Open();

                sqlCommand = new SqlCommand("p_EstadoCartera", SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@strId_Cliente", strId_Cliente));

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);

                EstadoCartera objcliente = new EstadoCartera();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ///solo comunes
                    objcliente.intIdTienda = Convert.ToInt32(ds.Tables[0].Rows[0]["intIdTienda"].ToString()); /// se presenta error si se deja .ToString() /// Campo fijo por ZONA PAGOS
                    objcliente.strPassword = ds.Tables[0].Rows[0]["strPassword"].ToString();
                    objcliente.strId_Cliente = strId_Cliente;
                    objcliente.strclave_cliente = ds.Tables[0].Rows[0]["strclave_cliente"].ToString();
                    objcliente.strNombre_Cliente = ds.Tables[0].Rows[0]["strNombre_Cliente"].ToString();
                    objcliente.strApellidos_Cliente = ds.Tables[0].Rows[0]["strApellidos_Cliente"].ToString();
                    objcliente.strEmail = ds.Tables[0].Rows[0]["strEmail"].ToString();
                    objcliente.strTelefono = ds.Tables[0].Rows[0]["strTelefono"].ToString();
                    objcliente.strCampo1 = ds.Tables[0].Rows[0]["strCampo1"].ToString();
                    objcliente.strCampo2 = ds.Tables[0].Rows[0]["strCampo2"].ToString();
                    objcliente.strCampo3 = ds.Tables[0].Rows[0]["strCampo3"].ToString();
                    objcliente.Cod_servicio_principal = ds.Tables[0].Rows[0]["Cod_servicio_principal"].ToString();
                    objcliente.Es_multicredito = ds.Tables[0].Rows[0]["Es_multicredito"].ToString();
                    //campo listaFacturas
                    //Cliente objclientefac = new Factura();
                    objcliente.facFacturas = new List<Factura>();

                    foreach (DataRow Datarow in ds.Tables[0].Rows)
                    {
                        objcliente.facFacturas.Add(new Factura
                        {
                            strNumero_Factura = Datarow["strNumero_Factura"].ToString(),
                            strConcepto = Datarow["strConcepto"].ToString(),
                            dblTotal_Con_Iva = Convert.ToDouble(Datarow["dblTotal_Con_Iva"].ToString()), /// se presenta error si se deja .ToString()
                            dblValor_Iva = Convert.ToDouble(Datarow["dblValor_Iva"].ToString()), /// se presenta error si se deja .ToString()
                            datFecha_Vencimiento = DateTime.Parse(Datarow["datFecha_Vencimiento"].ToString()), /// se presenta error si se deja .ToString()
                            Codigo_servicio_multicredito = Datarow["Codigo_servicio_multicredito"].ToString(),
                            Nit_codigo_servicio_multicredito = Datarow["Nit_codigo_servicio_multicredito"].ToString(),
                            Strcampo1 = Datarow["Referencia"].ToString()
                        });
                    }
                }
                return objcliente;

            }
            catch (Exception ex) { throw ex; }
            finally { SqlConnection.Close(); }
        }
               
    }


    /// <summary>
    /// ///////// Asentar Pagos 
    /// </summary>
   
}