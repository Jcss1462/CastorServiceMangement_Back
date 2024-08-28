using CastorServiceMangement_Back.Data;
using CastorServiceMangement_Back.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//inicializo en contexto
builder.Services.AddSqlServer<CastorDbContext>(builder.Configuration.GetConnectionString("cnCastor"));

//creo la inversion de dependencia
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ICargoService, CargoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()   // Permitir cualquier origen
                       .AllowAnyHeader()   // Permitir cualquier encabezado
                       .AllowAnyMethod();  // Permitir cualquier m�todo HTTP
            });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Aplicar la pol�tica CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
