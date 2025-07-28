using FaturamentoService.Data;
using FaturamentoService.Mapping;
using FaturamentoService.Repositories;
using FaturamentoService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FaturamentoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddHttpClient<IEstoqueClient, EstoqueClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5143"); 
});


builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization(); 
app.MapControllers();
app.Run();
