using System.Text.Json.Serialization;

namespace TranslatorJsonAndXml.Models
{
    public class EnviarPedido
    {
        [JsonPropertyName("enviarPedido")]
        public required PedidoRequest EnviarPedidoData { get; set; }
    }
}
