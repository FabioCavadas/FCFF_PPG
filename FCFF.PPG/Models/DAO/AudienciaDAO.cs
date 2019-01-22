using FCFF.PPG.Models.DB;
using System;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;
using FCFF.PPG.Models.ModelView;

namespace FCFF.PPG.Models.DAO
{
    public class AudienciaDAO : Conexao
    {
        public void Cadastrar(Audiencia a)
        {
            OpenConnection();

            string query = "INSERT INTO AUDIENCIA(Pontos, DataHora, IdEmissora) " +
                        "VALUES(@Pontos, @DataHora, @IdEmissora)";                         

            cmd = new SqlCommand(query, con);            
            cmd.Parameters.AddWithValue("@Pontos", a.Pontos);
            cmd.Parameters.AddWithValue("@DataHora", a.DataHora);
            cmd.Parameters.AddWithValue("@IdEmissora", a.IdEmissora);            
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public bool AudienciaExistente(int Id)
        {
            OpenConnection();

            string query = "select count(Id) from AUDIENCIA where Id = @Id ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            CloseConnection();
            return count > 0;
        }

        public List<AudienciaView> PesquisaAudienciaData(DateTime dti, DateTime dtf)
        {
            OpenConnection();

            string query = "select e.Nome, a.Pontos, a.DataHora "+
            "from AUDIENCIA a "+
            "inner join EMISSORA e "+
            "on a.IdEmissora = e.Id "+
            "where CONVERT(DATE, a.DataHora) Between @DTI and @DTF "+
            "order by e.Nome, a.DataHora ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DTI", dti);
            cmd.Parameters.AddWithValue("@DTF", dtf);            
            dr = cmd.ExecuteReader();

            List<AudienciaView> lista = new List<AudienciaView>();

            while (dr.Read())
            {
                AudienciaView a = new AudienciaView();

                a.Nome = Convert.ToString(dr["Nome"]);                
                a.Pontos = Convert.ToInt32(dr["Pontos"]);
                a.DataHora = Convert.ToDateTime(dr["DataHora"]);
                
                lista.Add(a);
            }

            CloseConnection();
            return lista;
        }
        
        public List<AudienciaView> PesquisaSomatorioMediaAudiencia(string nome, DateTime data)
         {
            OpenConnection();

            string query = "select SUM(a.Pontos) as Somatorio, AVG(a.Pontos) as Media " +
                "from AUDIENCIA a "+
                "inner join EMISSORA e "+
                "on a.IdEmissora = e.Id "+
                "WHERE e.nome = @Nome and CONVERT(DATE, a.DataHora) = @Data " +
                "group by e.nome";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Data", data);
            dr = cmd.ExecuteReader();

            List<AudienciaView> lista = new List<AudienciaView>();

            while (dr.Read())
            {
                AudienciaView a = new AudienciaView();
                
                a.Somatorio = Convert.ToInt32(dr["Somatorio"]);
                a.Media = Convert.ToInt32(dr["Media"]);            
                
                lista.Add(a);
            }

            CloseConnection();
            return lista;
        }
        
    }
}