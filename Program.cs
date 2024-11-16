using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cargar configuraciones desde variables de entorno
builder.Configuration.AddEnvironmentVariables();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Formula 1 API",
        Version = "v1",
        Description = "F1 Api Documentation",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Carlos Pereira",
            Email = "carloscoto0103@gmail.com",
            Url = new Uri("https://pereira-carlos.web.app/"),
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permite cualquier origen
              .AllowAnyHeader()   // Permite cualquier encabezado
              .AllowAnyMethod();  // Permite cualquier método (GET, POST, PUT, DELETE, etc.)
    });
});

// Configurar Kestrel para usar un puerto específico
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001); // Escuchar en el puerto 5001
});

var app = builder.Build();

// Configurar Swagger en el pipeline de la aplicación
if (app.Environment.IsDevelopment()) // Opcional: Solo en desarrollo
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty; // Hace que Swagger esté en la raíz (localhost:5000)
    });
}

// Aplicar la política de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
