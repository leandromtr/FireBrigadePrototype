using MapaDaForca.Model;
using System.Collections.Generic;

namespace MapaDaForca.ViewModel
{
    public class ViaturaTipoViewModel
    {
        public ViaturaTipo ViaturaTipo { get; set; }

        public List<ViaturaTipoFuncao> ViaturaTipoFuncoes { get; set; }

        public ViaturaTipoFuncaoViewModel ViaturaTipoFuncaoViewModel { get; set; }
    }
}
