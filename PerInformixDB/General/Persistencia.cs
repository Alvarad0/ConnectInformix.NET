using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerInformixDB.General
{
    public class Persistencia
    {
        #region Atributos
        public static string NombreCadenaConexion = "DBConnectionString";

        private string cadenaConexion = ConfigurationManager.ConnectionStrings != null && ConfigurationManager.ConnectionStrings[NombreCadenaConexion] != null ? ConfigurationManager.ConnectionStrings[NombreCadenaConexion].ConnectionString : "";

        public string CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        private IfxConnection conexion;

        public IfxConnection Conexion { get { return conexion; } }

        /// <summary>
        /// Inicializa la conexión establecida
        /// </summary>
        public void AbrirConexion()
        {
            if (conexion == null)
                conexion = new IfxConnection(cadenaConexion);

            if (conexion.State == ConnectionState.Closed)
            {
                conexion = new IfxConnection(cadenaConexion);
                conexion.Open();
            }
        }

        /// <summary>
        /// Finaliza la conexión establecida
        /// </summary>
        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        /// <summary>
        /// Establece la conexión a utilizar
        /// </summary>
        /// <param name="conn"></param>
        public void AsignarConexion(object conn)
        {
            if (conn is IfxConnection)
                conexion = conn as IfxConnection;
            else if (conexion != null)
            {
                conexion.Dispose();
                conexion = null;
            }
        }
        #endregion
    }

    //public void MakeConnection()
    //    {
    //        string HOST = "abmtyparaiso4";
    //        string SERVICENUM = "1426";
    //        string SERVER = "172.16.5.206";
    //        string DATABASE = "/pcz";
    //        string USER = "informix";
    //        string PASSWORD = "informix";

    //        string ConnectionString = "Host=" + HOST + "; " +
    //         "Service=" + SERVICENUM + "; " +
    //         "Server=" + SERVER + "; " +
    //         "Database=" + DATABASE + "; " +
    //         "User Id=" + USER + "; " +
    //         "Password=" + PASSWORD + "; ";
    //        //Can add other DB parameters here like DELIMIDENT, DB_LOCALE etc
    //        //Full list in Client SDK's .Net Provider Reference Guide p 3:13
    //        IfxConnection conn = new IfxConnection();
    //        conn.ConnectionString = ConnectionString;
    //        try
    //        {
    //            conn.Open();
    //            Console.WriteLine("Made connection!");
    //            Console.ReadLine();
    //        }
    //        catch (IfxException ex)
    //        {
    //            Console.WriteLine("Problem with connection attempt: "
    //                              + ex.Message);
    //        }
     //  }
    //}
}
