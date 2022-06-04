using Loja.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<EmpresaDataContext>();


var app = builder.Build();
app.MapControllers();

app.Run();
