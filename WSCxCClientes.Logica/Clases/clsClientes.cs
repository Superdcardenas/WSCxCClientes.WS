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

        public EstadoCartera strIdCliente(int intIdTienda = 0, string strPassword = "", string strId_Cliente = "", string strclave_cliente = "", List<Factura> facFacturas = null, string strNombre_Cliente = "", string strApellidos_Cliente = "", string strEmail = "", string strTelefono = "", string strCampo1 = "", string strCampo2 = "", string strCampo3 = "", string cod_servicio_principal = "", string es_multicredito = "", string strError = "") ////Obligatorio - Identificación Cliente
        //public EstadoCartera strIdCliente(int intIdTienda, string strPassword, string strId_Cliente, string strclave_cliente, List<Factura> facFacturas, string strNombre_Cliente, string strApellidos_Cliente, string strEmail, string strTelefono, string strCampo1, string strCampo2, string strCampo3, string cod_servicio_principal, string es_multicredito, string strError) ////Obligatorio - Identificación Cliente
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

                EstadoCartera mtEstadoCartera = new EstadoCartera();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ///solo comunes
                    mtEstadoCartera.intIdTienda = Convert.ToInt32(ds.Tables[0].Rows[0]["intIdTienda"].ToString()); /// se presenta error si se deja .ToString() /// Campo fijo por ZONA PAGOS
                    mtEstadoCartera.strPassword = ds.Tables[0].Rows[0]["strPassword"].ToString();
                    mtEstadoCartera.strId_Cliente = strId_Cliente;
                    mtEstadoCartera.strclave_cliente = ds.Tables[0].Rows[0]["strclave_cliente"].ToString();
                    mtEstadoCartera.strNombre_Cliente = ds.Tables[0].Rows[0]["strNombre_Cliente"].ToString();
                    mtEstadoCartera.strApellidos_Cliente = ds.Tables[0].Rows[0]["strApellidos_Cliente"].ToString();
                    mtEstadoCartera.strEmail = ds.Tables[0].Rows[0]["strEmail"].ToString();
                    mtEstadoCartera.strTelefono = ds.Tables[0].Rows[0]["strTelefono"].ToString();
                    mtEstadoCartera.strCampo1 = ds.Tables[0].Rows[0]["strCampo1"].ToString();
                    mtEstadoCartera.strCampo2 = ds.Tables[0].Rows[0]["strCampo2"].ToString();
                    mtEstadoCartera.strCampo3 = ds.Tables[0].Rows[0]["strCampo3"].ToString();
                    mtEstadoCartera.Cod_servicio_principal = ds.Tables[0].Rows[0]["Cod_servicio_principal"].ToString();
                    mtEstadoCartera.Es_multicredito = ds.Tables[0].Rows[0]["Es_multicredito"].ToString();
                    //campo listaFacturas
                    //Cliente objclientefac = new Factura();
                    mtEstadoCartera.facFacturas = new List<Factura>();

                    foreach (DataRow Datarow in ds.Tables[0].Rows)
                    {
                        mtEstadoCartera.facFacturas.Add(new Factura
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
                return mtEstadoCartera;

            }
            catch (Exception ex) { throw ex; }
            finally { SqlConnection.Close(); }
        }
               
    }


    /// <summary>
    /// ///////// Asentar Pagos 
    /// </summary>

    public class PagoFactura
    {
        SqlCommand sqlCommand = null;
        SqlConnection SqlConnection = null;
        SqlParameter sqlParameter = null;
        SqlDataAdapter SqlDataAdapter = null;

        string stConexion;

        public PagoFactura()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }


        public SqlCommand SqlCommand { get; private set; }

        public string AsentarPago(
             int intIdTienda,
             int intNumeroPago,
             string strPassword,
             string pfcPagoFactura,    //// es un arreglo con la información.
             int IntNumero_Facturas,
             DateTime datFechaTransaccion,
             int intEstado_Pago,
             int IntId_Forma_Pago,
             Double dblValor_Pagado,
             string srtTickeID,
             string strId_Cliente,
             string strFranquicia,
             string strCodigo_Aprobacion,
             string strCodigo_Servicio,
             string strCodigo_Banco,
             string strNombre_Banco,
             string strCodigo_Transaccion,
             int intCiclo_Transaccion,
             string strCampo1,
             string strCampo2,
             string strCampo3,
             string strInfo_Comercio)
        {
            try
            {
                SqlConnection = new SqlConnection(stConexion);
                SqlConnection.Open();

                sqlCommand = new SqlCommand("AsentarPagoPSE", SqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@intIdTienda", intIdTienda));
                sqlCommand.Parameters.Add(new SqlParameter("@intNumeroPago", intNumeroPago));
                sqlCommand.Parameters.Add(new SqlParameter("@strPassword", strPassword));
                sqlCommand.Parameters.Add(new SqlParameter("@pfcPagoFactura", pfcPagoFactura)); //debe ser un arreglo
                sqlCommand.Parameters.Add(new SqlParameter("@IntNumero_Facturas", IntNumero_Facturas));
                sqlCommand.Parameters.Add(new SqlParameter("@datFechaTransaccion", datFechaTransaccion));
                sqlCommand.Parameters.Add(new SqlParameter("@intEstado_Pago", intEstado_Pago));
                sqlCommand.Parameters.Add(new SqlParameter("@IntId_Forma_Pago", IntId_Forma_Pago));
                sqlCommand.Parameters.Add(new SqlParameter("@dblValor_Pagado", dblValor_Pagado));
                sqlCommand.Parameters.Add(new SqlParameter("@srtTickeID", srtTickeID));
                sqlCommand.Parameters.Add(new SqlParameter("@strId_Cliente", strId_Cliente));
                sqlCommand.Parameters.Add(new SqlParameter("@strFranquicia", strFranquicia));
                sqlCommand.Parameters.Add(new SqlParameter("@strCodigo_Aprobacion", strCodigo_Aprobacion));
                sqlCommand.Parameters.Add(new SqlParameter("@strCodigo_Servicio", strCodigo_Servicio));
                sqlCommand.Parameters.Add(new SqlParameter("@strCodigo_Banco", strCodigo_Banco));
                sqlCommand.Parameters.Add(new SqlParameter("@strNombre_Banco", strNombre_Banco));
                sqlCommand.Parameters.Add(new SqlParameter("@strCodigo_Transaccion", strCodigo_Transaccion));
                sqlCommand.Parameters.Add(new SqlParameter("@intCiclo_Transaccion", intCiclo_Transaccion));
                sqlCommand.Parameters.Add(new SqlParameter("@strCampo1", strCampo1));
                sqlCommand.Parameters.Add(new SqlParameter("@strCampo2", strCampo2));
                sqlCommand.Parameters.Add(new SqlParameter("@strCampo3", strCampo3));
                sqlCommand.Parameters.Add(new SqlParameter("@strInfo_Comercio", strInfo_Comercio));

                sqlParameter = new SqlParameter
                {
                    ParameterName = "@cMensaje",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.ExecuteNonQuery();

                return sqlParameter.Value.ToString();
            }
            catch (Exception ex) { throw ex; }
            finally { SqlConnection.Close(); }
        }

    }


}