using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Audiencia
    {
        public int Id { get; set; }

        public int Pontos { get; set; }

        public DateTime DataHora { get; set; }

        public int IdEmissora { get; set; }


        public Audiencia()
        {

        }

        public Audiencia(int id, int pontos, DateTime dataHora, int idEmissora)
        {
            Id = id;
            Pontos = pontos;
            DataHora = dataHora;
            IdEmissora = idEmissora;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Pontos: {Pontos}, DataHora: {DataHora}, IdEmissora: {IdEmissora} ";

        }

    }
}
