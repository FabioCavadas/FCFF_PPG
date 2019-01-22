using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFF.PPG.Entidades
{
    public class Audiencia
    {
        public int Id { get; set; }

        public int Pontos { get; set; }

        public DateTime DataHora { get; set; }

        public int Emissora { get; set; }

        public List<Emissora> Emissoras { get; set; }

    }
}
