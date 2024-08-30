using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class ConsistenciaSimilaridade
    {
        public readonly ParametroRepository _repository;

        public ConsistenciaSimilaridade(ParametroRepository repository)
        {
            _repository = repository;
        }

        public List<ConsistenciasResponse> Consiste(List<PagadorDI> pagadores, List<Exportadores> exportadores)
        {
            int percentualSimilaridade = _repository.GetSimilaridade(TipoSimilaridade.OUTROS);

            var compareJaroDistance = new EqualityCompareJaroDistance(percentualSimilaridade);

            var pagadoresAgrupados = pagadores.GroupBy(pagador => pagador.Nome, compareJaroDistance).Select(select =>
            {
                PagadorDI pagador = new PagadorDI();
                pagador.Nome = select.Key;
                pagador.Valor = select.Sum(sum => sum.Valor);

                return pagador;
            }).ToList();

            var exportadoresAgrupados = exportadores.GroupBy(exportador => exportador.Nome, compareJaroDistance).Select(select =>
            {
                Exportadores pagador = new Exportadores();
                pagador.Nome = select.Key;
                pagador.ValorAplicado = select.Sum(sum => sum.ValorAplicado);

                return pagador;
            }).ToList();

            //AGORA FAÇO O QUE AQUI???????


            bool hasMatch = exportadoresAgrupados
                .Exists(exportador => pagadoresAgrupados.Any(pagador => compareJaroDistance.Equals(pagador.Nome, exportador.Nome) && pagador.Valor == exportador.ValorAplicado));


            //Caso não ache o par, gera insconsistência para todas as dis.
            return null;
        }
    }
}
