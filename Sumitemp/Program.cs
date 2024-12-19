using Logic;
using Logic.PersonLogic;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repository.AddressRepository;
using Repository.Repository.EmailRepository;
using Repository.Repository.PersonRepository;
using Repository.Repository.PhoneRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Se realiza la configuracion de la inyección de dependencias.
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IPersonLogic, PersonLogic>();


//Configuracion conexion a base de datos
builder.Services.AddDbContext<AplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
