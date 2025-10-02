using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using TranslatorJsonAndXml.Models;

namespace TranslatorJsonAndXml.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
 

        public TranslatorRepository() 
        {
        }

        public Task<string> EnviarPedidoAsync(EnviarPedido pedido)
        {
            var xmlRequest = $@"
        <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:env='http://WSDLs/EnvioPedidos/EnvioPedidosAcme'>
            <soapenv:Header/>
            <soapenv:Body>
                <env:EnvioPedidoAcme>
                    <EnvioPedidoRequest>
                        <pedido>{pedido.EnviarPedidoData.NumPedido}</pedido>
                        <Cantidad>{pedido.EnviarPedidoData.CantidadPedido}</Cantidad>
                        <EAN>{pedido.EnviarPedidoData.CodigoEAN}</EAN>
                        <Producto>{pedido.EnviarPedidoData.NombreProducto}</Producto>
                        <Cedula>{pedido.EnviarPedidoData.NumDocumento}</Cedula>
                        <Direccion>{pedido.EnviarPedidoData.Direccion}</Direccion>
                    </EnvioPedidoRequest>
                </env:EnvioPedidoAcme>
            </soapenv:Body>
        </soapenv:Envelope>";

            return Task.FromResult(xmlRequest.Trim());
        }

        public Task<PedidoResponse> EnviarPedidoRespuesta(string request)
        {
            var doc = XDocument.Parse(request);

            var responseNode = doc.Descendants().FirstOrDefault(e => e.Name.LocalName == "EnvioPedidoResponse");

            if (responseNode == null)
                throw new InvalidOperationException("No se encontró el nodo EnvioPedidoResponse en el XML.");

            var respuesta = new PedidoResponse
            {
                EnviarPedidoRespuesta = new Envio
                {
                    CodigoEnvio = responseNode.Element(responseNode.Name.Namespace + "Codigo")?.Value,
                    Estado = responseNode.Element(responseNode.Name.Namespace + "Mensaje")?.Value
                }
            };


            return Task.FromResult(respuesta);
        }

    }
}
