using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using NWSInventaire.Server.Data;
using NWSInventaire.Server.HostedService;
using NWSInventaire.Server.Repository;
using PingEquipementCavasXpert.Classes;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
    );

builder.Services.AddScoped<MaterialRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<MaterialCategorieRepository>();
builder.Services.AddScoped<LendRepository>();

builder.Services.AddScoped<MailService>();

builder.Services.AddHostedService<LendHostedService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
