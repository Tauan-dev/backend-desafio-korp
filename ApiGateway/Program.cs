using ApiGateway.Clients;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configurar HttpClients para os serviços
builder.Services.AddHttpClient<IEstoqueClient, EstoqueClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5143");
});

builder.Services.AddHttpClient<IFaturamentoClient, FaturamentoClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5036");
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware padrão
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

Console.WriteLine("API Gateway rodando em: http://localhost:5093");

app.Run();
