global using Serilog;

using StoreBL;
using StoreDL;


// Initializing program logging for debugging
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/debuglog.txt") //We configure our logger to save in this file
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("StoreDatabase")));
builder.Services.AddScoped<ICostumerBL, CostumerBL>();
builder.Services.AddScoped<IStoreFrontBL, StoreFrontBL>();

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
