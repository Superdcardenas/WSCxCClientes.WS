using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSCxCClientes.Logica.Clases
{
    public class EstadoCartera
    {
        /// <summary>
        /// campos que solo corresponden a la Factura
        /// </summary>
        public int intIdTienda { get; set; } // se debe realizar el apuntamiento a la base de datos con la información de la factura
        public string strPassword { get; set; } ////Obligatorio - Contraseña de identificación en Zona Pagos
        public string strId_Cliente { get; set; } ////Obligatorio - Identificación Cliente
        public string strclave_cliente { get; set; } ///// clave cliente no es obligatoria
        public List<Factura> facFacturas { get; set; } ////Obligatorio - array con las facturas que debe pagar cada persona.
        public string strNombre_Cliente { get; set; } //// nombre de cliente
        public string strApellidos_Cliente { get; set; } //// apellidos cliente
        public string strEmail { get; set; } //// email del cliente
        public string strTelefono { get; set; } /// telefono del cliente
        public string strCampo1 { get; set; } /// campo con información opcional
        public string strCampo2 { get; set; } /// campo con información opcional
        public string strCampo3 { get; set; } /// campo con información opcional
        public string Cod_servicio_principal { get; set; } ////Obligatorio - Codigo de servicio que se utilizará para realizar los pagos. debe estar creado en PSE y en ZonaPagos
        public string Es_multicredito { get; set; } //// 1 Indica que se utilizará la modalidad multicre´dito para realizar el pago de las facturas 0 o Null no se utiliza la modalidad)

        public EstadoCartera strIdCliente(int intIdTienda, string strPassword, string strId_Cliente, string strclave_cliente, List<Factura> facFacturas, string strNombre_Cliente, string strApellidos_Cliente, string strEmail, string strTelefono, string strCampo1, string strCampo2, string strCampo3, string cod_servicio_principal, string es_multicredito, string strError)
        {
            throw new NotImplementedException();
        }

        //public void strIdCliente(int intIdTienda, string strPassword, string strId_Cliente, string strclave_cliente, List<Factura> facFacturas, string strNombre_Cliente, string strApellidos_Cliente, string strEmail, string strTelefono, string strCampo1, string strCampo2, string strCampo3, string cod_servicio_principal, string es_multicredito, string strError)
        //{
        //    throw new NotImplementedException();
        //}

        public string strError { get; set; }     
    }
}
