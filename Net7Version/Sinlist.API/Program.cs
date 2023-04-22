using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Sinlist.API.Modules;
using Sinlist.BusinessLogic.Mapping;
using Sinlist.Core.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<SinlistDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(SinlistDbContext)).GetName().Name);
    }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<SinlistDbContext>();
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        if (Log.Logger == null || Log.Logger.GetType().Name == "SlientLogger")
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.RollingFile("log-{Date}.txt", retainedFileCountLimit: null, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
        Log.Fatal(ex, "Host terminated unexpectedly");
    }
    finally
    {
        Log.CloseAndFlush();
    }
}


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

