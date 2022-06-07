using FluentAssertions.Common;
using Loja.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetSection("ConnectionString").Value.ToString();

builder.Services.AddControllers();
builder.Services.AddDbContext<EmpresaDataContext>(options => options.UseSqlServer(connString)); 


var app = builder.Build();
app.MapControllers();

app.Run();
