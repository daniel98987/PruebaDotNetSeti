# TranslatorJsonAndXml Daniel Zambrano

Este proyecto es una **API en ASP.NET Core 8** diseñada para traducir mensajes entre **JSON** y **XML (SOAP)**, implementando el **patrón Repository** y una estructura de carpetas limpia para mantener la separación de responsabilidades,seguir el paso a paso para el archivo dockerfile.
## Solución prueba
SWAGGER 
http://localhost:8080/swagger/index.html

SOLUCIÓN PUNTO B y C (POST)
http://localhost:8080/api/TranslatorJsonAndXml/envioPedidos
)
body - json
{
	"enviarPedido": {
		"numPedido": "75630275",
		"cantidadPedido": "1",
		"codigoEAN": "00110000765191002104587",
		"nombreProducto": "Armario INVAL",
		"numDocumento": "1113987400",
		"direccion": "CR 72B 45 12 APT 301"
	}
}


---

## 🚀 Tecnologías utilizadas
- .NET 8 (ASP.NET Core Web API)
- C#
- Patrón Repository
- Middlewares personalizados
- Docker (multi-stage build)
- Postman para pruebas

---

## 📂 Estructura del proyecto
TranslatorJsonAndXml/
│
├── Controllers/
│ └── TranslatorJsonAndXmlController.cs # Controlador principal con endpoints
│
├── Middleware/
│ └── ErrorHandlingMiddleware.cs # Middleware global para manejo de errores
│
├── Models/
│ ├── Errors/
│ │ └── ApiError.cs # Clase estándar para respuestas de error
│ ├── EnviarPedido.cs # Modelo de entrada JSON → XML
│ ├── EnviarPedidoResponse.cs # Modelo de salida XML → JSON
│ ├── Envio.cs # Submodelo para respuesta
│ └── PedidoRequest.cs # Detalle de pedido
│
├── Repositories/
│ ├── ITranslatorRepository.cs # Interfaz del repositorio
│ └── TranslatorRepository.cs # Implementación del patrón Repository
│
├── Services/
│ └── TranslatorService.cs # Lógica de negocio que usa el repositorio
│
├── Properties/
│ └── launchSettings.json # Configuración local (puertos y perfiles)
│
├── Dockerfile # Configuración multi-stage build
├── .dockerignore # Exclusiones para Docker
├── .gitignore # Exclusiones para Git
├── appsettings.json # Configuración de la API
└── TranslatorJsonAndXml.http # Archivo de pruebas HTTP
## Configuración para docker Puerto 8080
## 🐳 Docker

El proyecto incluye un `Dockerfile` multi-stage para compilar y ejecutar la aplicación en un contenedor liviano.  

### 📂 Archivos relacionados
- `Dockerfile` → define cómo construir y ejecutar la API en contenedor.  
- `.dockerignore` → evita copiar archivos innecesarios como `bin/`, `obj/`, `.vs/`.  

---

### 🔹 1. Construir la imagen
Desde la raíz del proyecto (donde está el `Dockerfile`):

docker build -t translator-api .

### 🔹 2. Ejecutar el contenedor
docker run -d -p 8080:8080 --name translator-container translator-api







