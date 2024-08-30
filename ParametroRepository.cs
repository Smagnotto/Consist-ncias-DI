using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class ParametroRepository
    {
        public int GetSimilaridade(TipoSimilaridade tipoSimilaridade)
        {
            //DEVE BUSCAR NO DYNAMO
            return tipoSimilaridade == TipoSimilaridade.CHINA ? 88 : 80;
        }
    }
}
