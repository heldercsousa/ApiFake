using ApiFake1.Authentication;
using ApiFake1.DataGen;
using ApiFake1.Model;
using  Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
    x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "The API key to access the API",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        {
            scheme, new List<string>()
        }
    };
    x.AddSecurityRequirement(requirement);
});

var apiConfig = builder.Configuration.GetSection("ApiConfig").Get<ApiConfig>();
var ideAgente = apiConfig.IdeAgente;

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

DemandaGen.GerarDados();
InterrupcoesGen.CarregarDados(ideAgente);
DemandasDiversasGen.CarregarDados(ideAgente);


app.Run();
