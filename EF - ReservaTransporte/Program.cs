using EF___ReservaTransporte;
using EF___ReservaTransporte.Models;
using Microsoft.EntityFrameworkCore;
using static EF___ReservaTransporte.StrategyConcrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EfReservaTransporteContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"))
);

// Registro de las estrategias
builder.Services.AddTransient<IStrategyReserva, CarTransport>();
builder.Services.AddTransient<IStrategyReserva, BusTransport>();
builder.Services.AddTransient<IStrategyReserva, VanTransport>();

// Registro del contexto
builder.Services.AddTransient<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
