using Application;
using Persistence;
using Solvex.Dynamic365.ServiceClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.Configure<DynamicsConfig>(builder.Configuration.GetSection("DynamicsConfig"));

var dynamicsConfig = new DynamicsConfig();
builder.Configuration.GetSection("DynamicsConfig").Bind(dynamicsConfig);

builder.Services.AddSingleton(dynamicsConfig);

builder.Services.AddTransient<IDynamicsConsumptionApi, DynamicsConsumptionApi>();

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
