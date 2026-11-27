using Microsoft.AspNetCore.HttpOverrides;
using ChillTechnologies.API.Configuration;
using ChillTechnologies.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

// Detras del proxy de Render la peticion llega como http: estas cabeceras
// le dicen a la app que el cliente si venia por https, para que las urls
// que genere no salgan en http.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

// Swagger queda disponible tambien en produccion: es la documentacion
// de la API y lo que se usa para demostrar el proyecto.
app.UseSwagger();
app.UseSwaggerUI();

// Sin UseHttpsRedirection a proposito: Render ya termina TLS en su proxy,
// y redirigir desde la app provoca un bucle de 307.

// CORS va antes de todo lo que pueda responder, para que el preflight
// reciba sus cabeceras incluso cuando la peticion termine en error.
app.UseCors(ServiceRegistrationExtensions.CorsPolicy);

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
