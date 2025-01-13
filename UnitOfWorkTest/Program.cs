using Microsoft.EntityFrameworkCore;
using Serilog;
using UnitOfWorkTest;
using UnitOfWorkTest.Repositories;
using UnitOfWorkTest.Repositories.Classes;
using UnitOfWorkTest.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region Add file-based logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("logs/MyApplication.log", rollingInterval: RollingInterval.Infinite)
    .CreateLogger();
builder.Host.UseSerilog();  // for logging purposes
#endregion


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IActiveUserRepository, ActiveUserRepository>();
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
