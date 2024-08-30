using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{

    public class EqualityCompareJaroDistance : IEqualityComparer<string>
    {
        private readonly double percentualSimilaridade;
        public EqualityCompareJaroDistance(int percentualSimilaridade)
        {
            this.percentualSimilaridade = percentualSimilaridade / 100d;
        }

        public bool Equals(string? b1, string? b2)
        {
            if (b2 is null || b1 is null) return false;

            var result =  StringUtil.JaroDistance(b1, b2) >= percentualSimilaridade;

            return result;
        }

        public int GetHashCode(string obj)
        {
            return 1;
        }
    }
}
