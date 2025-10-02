using TranslatorJsonAndXml.Models;
using TranslatorJsonAndXml.Repositories;

namespace TranslatorJsonAndXml.Services
{
    public class TranslatorService
    {
        private readonly ITranslatorRepository _translatorRepository;

        public TranslatorService(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;
        }

        public async Task<string> TranslateJsonToXml(EnviarPedido request)
        {


            return await _translatorRepository.EnviarPedidoAsync(request);
        }
        public async Task<PedidoResponse> TranslateXmlToJson(string xml)
        {
       ;

            return await _translatorRepository.EnviarPedidoRespuesta(xml);
        }
    }
}
