using TranslatorJsonAndXml.Repositories;
using TranslatorJsonAndXml.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers + XML support
builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Registro de HttpClient para los servicios/repositorios
builder.Services.AddHttpClient<ITranslatorRepository, TranslatorRepository>();
builder.Services.AddScoped<TranslatorService>();


var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
