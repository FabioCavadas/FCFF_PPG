using Entidades;
using FCFF.PPG.Models.DB;
using FCFF.PPG.Models.ModelView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FCFF.PPG.Models.DAO
{
    public class EmissoraDAO : Conexao
    {
        public void Cadastrar(Emissora e)
        {
            OpenConnection();

            string query = "insert into EMISSORA(Nome) values(@Nome)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", e.Nome);           
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public bool EmissoraExistente(string Nome)
        {
            OpenConnection();

            string query = "select count(Nome) from Emissora where Nome = @Nome";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            CloseConnection();
            return count > 0;
        }

        public void Edicao(EmissoraView e)
        {
            OpenConnection();

            string query = "update Emissora set Nome = @Nome "+
                "where Id = @Id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", e.Id);
            cmd.Parameters.AddWithValue("@Nome", e.Nome);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public Emissora ObterPorId(int id)
        {
            OpenConnection();

            string query = "select * from Emissora where Id = @Id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);            
            dr = cmd.ExecuteReader();

            Emissora e = new Emissora();

            if (dr.Read()) 
            {                 
                e.Id = Convert.ToInt32(dr["Id"]);
                e.Nome = Convert.ToString(dr["Nome"]);
            }

            CloseConnection();
            return e; 
        }

        public void Remover(int id)
        {
            OpenConnection();

            string query = "delete from Audiencia  where IdEmissora = @Id";
           
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Emissora> ListarTodas()
        {
            OpenConnection();

            string query = "select * from Emissora";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            List<Emissora> lista = new List<Emissora>(); 
            
            while (dr.Read())
            {
                Emissora e = new Emissora();
                e.Id = Convert.ToInt32(dr["Id"]);
                e.Nome = Convert.ToString(dr["Nome"]);

                lista.Add(e); 
            }

            CloseConnection();
            return lista; 
        }



    }
}