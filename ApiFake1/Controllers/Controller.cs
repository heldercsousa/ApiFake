using Microsoft.AspNetCore.Mvc;
using ApiFake1.Model.Demanda;
using ApiFake1.DataGen;
using ApiFake1.Enumerables;
using ApiFake1.Model.Interrupcoes;
using ApiFake1.Model.DemandasDiversas;
using ApiFake1.Model;

namespace ApiFake1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private readonly int intervaloDeInteresse;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;

            var intervalos = Enumerable.Range(0, 48).Select(x => new
            {
                Intervalo = x,
                TotalMinutes = x * 30
            })
            .ToList();

            var hora = DateTime.Now.Hour;
            var minuto = DateTime.Now.Minute;
            var totalMinutes = (hora * 30) + minuto;

            intervaloDeInteresse = intervalos
            .Where(x => x.TotalMinutes >= totalMinutes)
            .OrderBy(x => x.TotalMinutes)
            .Select(x =>x.Intervalo)
            .First();

        }

        [HttpGet("DadosDemanda/{NumProtocolo}")]
        public DemandaResponseModel DadosDemanda(string NumProtocolo)
        {
            try
            {
                if (!string.IsNullOrEmpty(NumProtocolo))
                {
                    NumProtocolo = NumProtocolo.PadLeft(30, '0');
                }

                var demanda = DemandaGen.Demandas.SingleOrDefault(x => x.NumProtocolo == NumProtocolo);

                return new DemandaResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Sucesso.Key,
                    Mensagem = string.Empty,
                    Demanda = demanda
                };
            }
            catch (System.Exception ex)
            {
                return new DemandaResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Erro.Key,
                    Mensagem = ex.Message
                };
            }

        }

        [HttpGet("quantitativointerrupcoesativas")]
        public InterrupcoesResponseModel QuantitativoInterrupcoesAtivas()
        {
            try
            {
                var interr = InterrupcoesGen.Interrupcoes
                .Where(x => x.Dia == DateTime.Today.Day && x.Intervalo == intervaloDeInteresse)
                .ToArray();

                return new InterrupcoesResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Sucesso.Key,
                    Mensagem = string.Empty,
                    InterrupcaoFornecimento = interr
                };
            }
            catch (System.Exception ex)
            {
                return new InterrupcoesResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Erro.Key,
                    Mensagem = ex.Message
                };
            }

        }

        [HttpGet("quantitativodemandasdiversas")]
        public DemandasDiversasResponseModel QuantitativoDemandasDiversas()
        {
            try
            {
               
                var diver = DemandasDiversasGen.DemandasDiversas
                .Where(x => x.Dia == DateTime.Today.Day && x.Intervalo == intervaloDeInteresse)
                .ToArray();

                return new DemandasDiversasResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Sucesso.Key,
                    Mensagem = string.Empty,
                    DemandasDiversas = diver
                };
            }
            catch (System.Exception ex)
            {
                return new DemandasDiversasResponseModel
                {
                    IdcStatusRequisicao = ResponseStatus.Erro.Key,
                    Mensagem = ex.Message
                };
            }

        }
    }
}
