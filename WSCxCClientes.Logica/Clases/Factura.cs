using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSCxCClientes.Logica.Clases
{
    public partial class Factura
    {
        /// <summary>
        /// campos que solo corresponden a la Factura
        /// </summary>
        public string strNumero_Factura { get; set; } //Obligatorio - Alfanumérico único con el cual se identificará la obligación
        public string strConcepto { get; set; } ////Obligatorio - Descripción del Pago
        public Double dblTotal_Con_Iva { get; set; } ////Obligatorio - Total la pagar maximo 2 decimales
        public Double dblValor_Iva { get; set; } /////Obligatorio - como la Super no maneja IVA debe enviar 
        public DateTime datFecha_Vencimiento { get; set; } ////Opcional Fecha máxima de pago último día habil de agosto
        public string Codigo_servicio_multicredito { get; set; } ////Opcional - se debe enviar en 0 ya que la Supervigilancia no maneja esta modalidad.
        public string Nit_codigo_servicio_multicredito { get; set; } ////Opcional - se debe enviar en 0 ya que la Supervigilancia no maneja esta modalidad.
        public string Strcampo1 { get; set; } /// campo con información opcional
        /// <summary>
        /// Estos campos se envían en el método. 
        /// </summary>
        //public int intIdTienda { get; set; } // se debe realizar el apuntamiento a la base de datos con la información de la factura
        //public string strPassword { get; set; } ////Obligatorio - Contraseña de identificación en Zona Pagos
        //public string strId_Cliente { get; set; } ////Obligatorio - Identificación Cliente
        //public string strclave_cliente { get; set; } ///// clave cliente no es obligatoria
        //public List<Factura> facFacturas { get; set; } ////Obligatorio - array con las facturas que debe pagar cada persona.
        //public string strNombre_Cliente { get; set; } //// nombre de cliente
        //public string strApellidos_Cliente { get; set; } //// apellidos cliente
        //public string strEmail { get; set; } //// email del cliente
        //public string strTelefono { get; set; } /// telefono del cliente
        //public string strCampo1 { get; set; } /// campo con información opcional
        //public string strCampo2 { get; set; } /// campo con información opcional
        //public string strCampo3 { get; set; } /// campo con información opcional
        //public string Cod_servicio_principal { get; set; } ////Obligatorio - Codigo de servicio que se utilizará para realizar los pagos. debe estar creado en PSE y en ZonaPagos
        //public string Es_multicredito { get; set; } //// 1 Indica que se utilizará la modalidad multicre´dito para realizar el pago de las facturas 0 o Null no se utiliza la modalidad)
        //public string strError { get; set; }
    }
}
