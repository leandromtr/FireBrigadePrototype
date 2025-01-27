using MapaDaForca.Model;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class BombeiroEscalaViewModel
    {
        public Bombeiro Bombeiro { get; set; }

        public Escala Escala { get; set; }

        public List<Escala> Escalas { get; set; }

        public List<Funcao> Funcoes { get; set; }

        public List<Quartel> Quarteis { get; set; }

        public List<EscalaTipo> EscalaTipos { get; set; }
    }
}
