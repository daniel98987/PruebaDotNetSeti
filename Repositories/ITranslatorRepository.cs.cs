using TranslatorJsonAndXml.Models;

namespace TranslatorJsonAndXml.Repositories
{
    public interface ITranslatorRepository
    {
        Task<string> EnviarPedidoAsync(EnviarPedido request);
        Task<PedidoResponse> EnviarPedidoRespuesta(string request);

    }
}
