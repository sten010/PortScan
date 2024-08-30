using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using PortScan.Model;
using ServerScanPort.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ���������� �������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:5043") // ������� URL, � �������� ��������� �������
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();


builder.Services.AddControllersWithViews();

// ����������� HttpClient
builder.Services.AddHttpClient();

// ����������� �����
builder.Services.AddTransient<PageModel, ScanPortModel>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin"); // ���������� �������� CORS

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
    endpoints.MapControllers(); // ������������ �����������
});

app.MapControllers(); //������� ������������

app.Run();

