using TMom.Client.Endpoints;
using TMom.Client.Setup;

var builder = WebApplication.CreateSlimBuilder(args);

var services = builder.Services;
services.WithJsonConfiguration();
services.AddCorsSetup();

var app = builder.Build();

app.UseCors("CorsIpAccess");

app.MapPrintEndpoints();

app.Run("http://localhost:6663");