using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class Contrato
    {
        public int CodigoMoeda { get; set; }
        public List<Exportadores> Exportados { get; set; }
    }
}
