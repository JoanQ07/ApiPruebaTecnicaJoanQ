using Microsoft.EntityFrameworkCore;
using ruleta_api.Context;
using ruleta_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicio DB.
var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

// Services controller
builder.Services.AddScoped<IResultado, ResultadoServices>();
builder.Services.AddScoped<IUsuario, UsuariosServices>();
builder.Services.AddScoped<IPreemio, PremioServices>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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

app.UseHttpsRedirection();

// Aplicar la política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
