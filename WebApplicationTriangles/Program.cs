using Lab4;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connection = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddMvc();
builder.Services.AddDbContext<TrianglesContext>(options =>
    options.UseSqlServer(connection));
builder.Services.AddScoped<ITriangleProvider, TriangleProvider>();
builder.Services.AddScoped<ITriangleService, TriangleService>();
builder.Services.AddScoped<ITriangleValidateService, TriangleValidateService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseStatusCodePages();

//app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//name: "triangle",
//pattern: "{controller=ValuesController}/{action=Get}/?a={a}&b={b}&c={c}");

//    endpoints.MapControllerRoute(
//    name: "triangles",
//    pattern: "{controller=ValuesController}/{action=Get}");
//});

app.Run();
