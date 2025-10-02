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
            var xmlResponse = await _translatorService.TranslateJsonToXml(request);

            // 2. Transformar respuesta XML → JSON
            var jsonResponse = await _translatorService.TranslateXmlToJson(xmlResponse);

            // 3. Responder en formato JSON
            return Ok(jsonResponse);
        }
       


    }
}
