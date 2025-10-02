namespace TranslatorJsonAndXml.Models.Errors
{
    public class ApiError
    {
        public string Codigo { get; set; }      
        public string Mensaje { get; set; }        
        public string Detalle { get; set; }     
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }

}
