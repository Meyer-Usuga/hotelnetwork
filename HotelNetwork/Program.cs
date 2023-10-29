using HotelNetwork.DAL;
using HotelNetwork.Domain.Interfaces;
using HotelNetwork.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Conexión a la base de datos. 
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dependencias para las interfaces. 
builder.Services.AddScoped<IHotelsServices, HotelsService>();
builder.Services.AddScoped<IRoomsServices, RoomsService>();
builder.Services.AddTransient<SeederDB>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//para el seeder
SeederData();
void SeederData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

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
