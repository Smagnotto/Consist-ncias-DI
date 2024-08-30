using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class ConsistenciaParidade
    {
        public List<ConsistenciasResponse> Consiste(Contrato contrato, DeclaracaoImportacao declaracaoImportacao)
        {
            var itensDiferentes = from adicao in declaracaoImportacao.adicao
                                  where adicao.CodigoMoeda != contrato.CodigoMoeda
                                  select adicao;

            return (from item in itensDiferentes
                    select new ConsistenciasResponse()
                    {
                        Codigo = 1,
                        Criticidade = new CriticidadeResponse() { Sigla = "DEC", Tipo = "PARIDADE" },
                        Descricao = "Moeda da adição divergente da moeda do contrato",
                        NumeroAdicao = item.NumeroAdicao

                    }).ToList();
        }
    }
}
