using TranslatorJsonAndXml.Repositories;
using TranslatorJsonAndXml.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositorios y servicios
builder.Services.AddTransient<ITranslatorRepository, TranslatorRepository>();
builder.Services.AddScoped<TranslatorService>();
builder.Services.AddControllers()
    .AddXmlSerializerFormatters(); // <- habilita que ASP.NET Core entienda application/xml
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
