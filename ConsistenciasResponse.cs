using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class ConsistenciasResponse
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int NumeroAdicao { get; set; }
        public CriticidadeResponse Criticidade { get; set; } = default!;
    }
}
