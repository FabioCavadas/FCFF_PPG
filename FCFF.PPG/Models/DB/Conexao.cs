using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FCFF.PPG.Models.DB
{
    public class Conexao
    {
        
        protected SqlConnection con;    
        protected SqlCommand cmd;       
        protected SqlDataReader dr;    
        protected SqlTransaction tr;    

        //método para abrir conexão com o banco de dados..
        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PPG"].ConnectionString);
            con.Open();
        }

        //método para fechar conexão com o banco de dados..
        protected void CloseConnection()
        {
            con.Close();
        }

    }
}