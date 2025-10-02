using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TranslatorJsonAndXml.Models;
using TranslatorJsonAndXml.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TranslatorJsonAndXml.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorJsonAndXmlController : ControllerBase
    {
        private readonly TranslatorService _translatorService;

        public TranslatorJsonAndXmlController(TranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        [HttpPost("envioPedidos")]
        public async Task<IActionResult> EnviarPedido([FromBody] EnviarPedido request)
        {
            var response = await _translatorService.TranslateJsonToXml(request);
            return Ok(response);
        }
        [HttpPost("enviarPedidoRespuesta")]
        [Consumes("application/xml", "text/xml")] // acepta ambos tipos de SOAP
        public async Task<IActionResult> EnviarPedidoRespuesta()
        {
            // Leer el XML crudo
            using var reader = new StreamReader(Request.Body);
            string xmlBody = await reader.ReadToEndAsync();

            // Llamar a tu servicio para convertirlo a JSON
            var response = await _translatorService.TranslateXmlToJson(xmlBody);


            return Ok(response);
        }



    }
}
