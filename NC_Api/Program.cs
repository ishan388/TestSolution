using Microsoft.EntityFrameworkCore;
using NC_BLRepositories;
using NC_DLRepositories;
using Newtonsoft.Json.Serialization;
using System.Configuration;

var CorsPolicy = "MyPolicy";
var builder = WebApplication.CreateBuilder(args);

//CORS setting
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Dependency Injection Implementation

builder.Services.AddScoped<IDLProductsRepo, DLProductsRepo>();
builder.Services.AddScoped<IBLProductsRepo, BLProductsRepo>();
builder.Services.AddDbContext<MyShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
