
namespace InconsistenciasDeclaracaoImportacao
{
    public class ConsistenciaVinculo
    {
        private ConsistenciaParidade consistenciaParidade;
        private ConsistenciaSimilaridade consistenciaSimilaridade;

        public ConsistenciaVinculo(ConsistenciaParidade consistenciaParidade, ConsistenciaSimilaridade consistenciaSimilaridade)
        {
            this.consistenciaParidade = consistenciaParidade;
            this.consistenciaSimilaridade = consistenciaSimilaridade;
        }

        public List<ConsistenciasResponse> Consiste(string numeroDeclaracao, string numeroContrato, int numeroLiquidacaoParcial)
        {
            var consistencias = new List<ConsistenciasResponse>();
            //busca copntrato
            var contrato = new Contrato()
            {
                CodigoMoeda = 220,
                Exportados = new()
                {
                    new()
                    {
                        Nome = "EXPORTADOR 1",
                        ValorAplicado = 104
                    },
                    new()
                    {
                        Nome = "EXPORTADOR 2",
                        ValorAplicado = 304
                    }
                }
            };

            //Busca declaracao importação
            var declaracaoImportacao = new DeclaracaoImportacao()
            {
                adicao = new()
                {
                    new()
                    {
                        NumeroAdicao  = 1,
                        CodigoMoeda = 978
                    },
                    new()
                    {
                        NumeroAdicao  = 2,
                        CodigoMoeda = 220
                    },
                    new()
                    {
                        NumeroAdicao  = 3,
                        CodigoMoeda = 515
                    }
                }
            };


            var pagadores = new List<PagadorDI>()
            {
                new()
                {
                    Nome = "JOSE DA SILVA SANTOS",
                    Valor = 54
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGTAS SARAIVA",
                    Valor = 100
                },
                new()
                {
                    Nome = "JOSE DA  SANTOS",
                    Valor = 100
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGNOT SARAIVA",
                    Valor = 13
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGTAS SARAIVA",
                    Valor = 100
                },
            };

            var exportadores = new List<Exportadores>()
            {
                new()
                {
                    Nome = "JOSE DA SILVA SANTOS",
                    ValorAplicado = 54
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGTAS SARAIVA",
                    ValorAplicado = 100
                },
                new()
                {
                    Nome = "JOSE DA  SANTOS",
                    ValorAplicado = 100
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGNOT SARAIVA",
                    ValorAplicado = 13
                },
                new()
                {
                    Nome = "DIEGO SOARES SMAGTAS SARAIVA",
                    ValorAplicado = 99
                },
            };


            consistencias.AddRange(consistenciaParidade.Consiste(contrato, declaracaoImportacao));
            consistencias.AddRange(consistenciaSimilaridade.Consiste(pagadores, exportadores));

            return consistencias;
        }
    }
}