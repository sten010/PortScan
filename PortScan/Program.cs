using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using PortScan.Model;
using ServerScanPort.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Добавление политики CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:5043") // Укажите URL, с которого разрешены запросы
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();


builder.Services.AddControllersWithViews();

// Регистрация HttpClient
builder.Services.AddHttpClient();

// Регистрация служб
builder.Services.AddTransient<PageModel, ScanPortModel>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin"); // Применение политики CORS

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Регистрируем контроллеры
});

app.MapControllers(); //маппинг контроллеров

app.Run();

