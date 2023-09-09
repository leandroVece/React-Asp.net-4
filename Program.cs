using Cadeteria;
using Cadeteria.Authorization;
using Cadeteria.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllersWithViews();

    // if (builder.Environment.IsProduction())
    //     builder.Services.AddDbContext<DataContext>();
    // else
    builder.Services.AddSqlServer<DataContext>(builder.Configuration.GetConnectionString("SQLServer"));

    builder.Services.AddCors();
    builder.Services.AddControllers();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // configure automapper with all automapper profiles from this assembly
    builder.Services.AddAutoMapper(typeof(Program));

    // configure strongly typed settings object
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


    builder.Services.AddScoped<IJwtUtils, JwtUtils>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IRolRepository, RolRepository>();
    builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
    builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
    builder.Services.AddScoped<ICadetePedidoRepository, CadetePedidoRepository>();
    builder.Services.AddScoped<IHistorialRepository, HistorialRepository>();
    builder.Services.AddScoped<IArticuloCategoriaRepository, ArticuloCategoriaRepository>();
    builder.Services.AddScoped<IArchivoRepository, ArchivoRepository>();
    builder.Services.AddScoped<IArchivoHelpers, ArchivoHelpers>();
    // builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    // using (var scope = app.Services.CreateScope())
    // {
    //     var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    //     dataContext.Database.Migrate();
    // }

    {
        // global cors policy
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        // global error handler
        app.UseMiddleware<ErrorHandlerMiddleware>();

        // custom jwt auth middleware
        app.UseMiddleware<JwtMiddleware>();

        app.MapControllers();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html"); ;

    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
