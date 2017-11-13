using IBM.Data.Informix;
using PerInformixDB.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerInformixDB.Catalogos
{
    public class PerCatalogo : Persistencia
    {

        public List<string> ObtenerTodos()
        {
            List<string> Lista = new List<string>();            
            try
            {
                AbrirConexion();
                IfxCommand cmd = new IfxCommand("select * from claves_proveedor", Conexion);
                IfxDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string descripcion =  dr["descripcion"].ToString();
                    Lista.Add(descripcion);
                }
                dr.Close();
            }
            catch (IfxException ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return Lista;
        }
    }
}
