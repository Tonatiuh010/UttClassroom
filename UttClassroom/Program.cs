using Engine.Constants;
using Engine.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapGet("/", () => "Classroom API is working...");

ClassroomCredentials.ConnectionCallback = () => builder.Configuration.GetConnectionString(C.CLASSROOM);
//ControlAccessDAL.SetOnConnectionException((ex, msg) => Console.WriteLine($"Error Opening connection {msg} - {ex.Message}"));

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"
);

app.Run();
