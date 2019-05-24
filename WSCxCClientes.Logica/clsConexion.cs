using System.Configuration;

namespace WSCxCClientes.Logica.Clases
{
    class clsConexion
    {
        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}
