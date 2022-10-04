using Classes;
using Engine.BL;
using Engine.Constants;
using Engine.Services;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.Services.AddControllers(options =>
//{
//    options.OutputFormatters.Add()
//});
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost",
                            "http://localhost:4200");
    });
});
//builder.Services.Configure<JsonOptions>(o =>
//{
//    o.SerializerOptions.WriteIndented = true;
//});

var app = builder.Build();
app.MapGet("/", () => "Classroom API is working...");

ClassroomCredentials.ConnectionCallback = () => builder.Configuration.GetConnectionString(C.CLASSROOM);
BaseBL.SetErrorsCallback(
    //CustomController.,
    (ex, msg) => Console.WriteLine($"Error Opening connection {msg} - {ex.Message}")
);
BinderBL.Start();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();    
}

app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
//(builder =>
//{
//    builder
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"
);

app.Run();
