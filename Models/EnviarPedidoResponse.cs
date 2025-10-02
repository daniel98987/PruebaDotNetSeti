using System.Text.Json.Serialization;

namespace TranslatorJsonAndXml.Models
{
    public class PedidoResponse
    {
        [JsonPropertyName("enviarPedidoRespuesta")]
        public required Envio EnviarPedidoRespuesta { get; set; }
    }
}
