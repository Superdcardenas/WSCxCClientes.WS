using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using WSCxCClientes.Logica.Clases;
using System.IO;
using System.Xml.Serialization;
using System.Text;
/// <summary>
/// Descripción breve de WSClientes
/// </summary> 
[WebService(Namespace = "http://www.SUCOMERCIO.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSClientes : System.Web.Services.WebService
{

    public WSClientes()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void EstadoCartera(
        int intIdTienda,
        string strPassword,
        string strId_Cliente,//El que se tenia de antemano
        string strclave_cliente,
        List<Factura> facFacturas, ///array que viene de una lista
        string strNombre_Cliente,
        string strApellidos_Cliente,
        string strEmail,
        string strTelefono,
        string strCampo1,
        string strCampo2,
        string strCampo3,
        string Cod_servicio_principal,
        string Es_multicredito,
        string strError

        ) ////Obligatorio - Identificación Cliente

    {
        try
        {
            WSCxCClientes.Logica.Clases.EstadoCartera obclsClientes = new WSCxCClientes.Logica.Clases.EstadoCartera();
            Context.Response.Write(GetXml(strId_Cliente));
            //return obclsClientes.mtEstadoCartera(
            //    intIdTienda,
            //    strPassword,
            //    strId_Cliente, //El que se tenia de antemano
            //    strclave_cliente,
            //    facFacturas, ///array que viene de una lista de la clase factura
            //    strNombre_Cliente,
            //    strApellidos_Cliente,
            //    strEmail,
            //    strTelefono,
            //    strCampo1,
            //    strCampo2,
            //    strCampo3,
            //    Cod_servicio_principal,
            //    Es_multicredito,
            //    strError
            //    );

        }
        catch (Exception ex) { throw ex; }
    }

        public string GetXml(string strId_Cliente)
        {
            var objconsulta = new WSCxCClientes.Logica.Clases.ConsultaFactura();
            string response = string.Empty;
        EstadoCartera obj = objconsulta.strIdCliente(0,"",strId_Cliente);
        //EstadoCartera obj = objconsulta.strId_Cliente(intIdTienda, strPassword, strId_Cliente, strclave_cliente, facFacturas, strNombre_Cliente, strApellidos_Cliente, strEmail, strTelefono, strCampo1, strCampo2, strCampo3, cod_servicio_principal, es_multicredito, strError);
        using (var MemoryStream = new MemoryStream())
            {
                using (TextWriter streamwriter = new StreamWriter(MemoryStream))
                {
                    var xmlserializer = new XmlSerializer(typeof(EstadoCartera));
                    xmlserializer.Serialize(streamwriter, obj);
                    response = Encoding.UTF8.GetString(MemoryStream.ToArray());
                }

            }

            return response;
        }

    [WebMethod]
    public string AsentarPago(
             int intIdTienda,
             int intNumeroPago,
             string strPassword,
             string pfcPagoFactura,   // Debe ser un tipo array
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
            WSCxCClientes.Logica.Clases.PagoFactura obclsClientes = new WSCxCClientes.Logica.Clases.PagoFactura();
            return obclsClientes.AsentarPago(
             intIdTienda,
             intNumeroPago,
             strPassword,
             pfcPagoFactura,
             IntNumero_Facturas,
             datFechaTransaccion,
             intEstado_Pago,
             IntId_Forma_Pago,
             dblValor_Pagado,
             srtTickeID,
             strId_Cliente,
             strFranquicia,
             strCodigo_Aprobacion,
             strCodigo_Servicio,
             strCodigo_Banco,
             strNombre_Banco,
             strCodigo_Transaccion,
             intCiclo_Transaccion,
             strCampo1,
             strCampo2,
             strCampo3,
             strInfo_Comercio);

        }
        catch (Exception ex) { throw ex; }


    }


}
