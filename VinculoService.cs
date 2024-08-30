using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class VinculoService
    {
        private readonly ConsistenciasService consistenciasService;
        private readonly ConsistenciaVinculo consistenciaVinculo;

        public VinculoService(ConsistenciasService consistenciasService, ConsistenciaVinculo consistenciaVinculo)
        {
            this.consistenciasService = consistenciasService;
            this.consistenciaVinculo = consistenciaVinculo;
        }

        public void Insert()
        {
            if (!consistenciasService.GetAllConsistencias("12948719", "1", 1).Any())
            {
                //não tem inconsistencia, tenta vincular
                var consistencias = consistenciaVinculo.Consiste("12948719", "1", 1);
                if (consistencias is null || !consistencias.Any())
                {
                    // insere os vinculos


                }

            }

            throw new Exception("Não foi possível realizar o vinculo, pois existe inconsistências");
        }
    }
}
