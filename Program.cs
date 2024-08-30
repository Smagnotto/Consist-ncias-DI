// See https://aka.ms/new-console-template for more information
using InconsistenciasDeclaracaoImportacao;

Console.WriteLine("Hello, World!");

var service = new VinculoService(new ConsistenciasService(), new ConsistenciaVinculo(new ConsistenciaParidade(), new ConsistenciaSimilaridade(new ParametroRepository())));

service.Insert();