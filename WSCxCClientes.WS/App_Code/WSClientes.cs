using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using WSCxCClientes.Logica.Clases;
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
    public EstadoCartera EstadoCartera(
        int intIdTienda,
        string strPassword,
        string strId_Cliente, //El que se tenia de antemano
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
            return obclsClientes.strIdCliente(
                intIdTienda,
                strPassword,
                strId_Cliente, //El que se tenia de antemano
                strclave_cliente,
                facFacturas, ///array que viene de una lista de la clase factura
                strNombre_Cliente,
                strApellidos_Cliente,
                strEmail,
                strTelefono,
                strCampo1,
                strCampo2,
                strCampo3,
                Cod_servicio_principal,
                Es_multicredito,
                strError
                );

        }
        catch (Exception ex) { throw ex; }
    }


    
}
