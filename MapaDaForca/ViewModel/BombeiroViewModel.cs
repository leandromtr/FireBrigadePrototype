using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapaDaForca.ViewModel
{
    public class BombeiroViewModel
    {
        public Bombeiro Bombeiro { get; set; }

        public List<BombeiroFuncao> BombeiroFuncoes { get; set; }
        
    }
}
