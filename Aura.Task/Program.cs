
using Aura.PracticalTask.Data;
using Aura.PracticalTask.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Aura.PracticalTask;

public class Program
{
    public static  async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        #region Configure Services

        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerServices();

        // add the app services to DI Container
        builder.Services.AddApplicationServices();

        #region DataBase
        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

        #endregion


        #endregion

        var app = builder.Build();

        //  applay all migrations when the app start
        #region MigrateTheDB

        var ServicesScope = app.Services.CreateScope();

        using var context = ServicesScope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();

        #endregion

        // Configure the HTTP request pipeline.
        #region Confugre MiddleWears
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerMiddleWeres();
        }
        app.UseStaticFiles();

        app.UseFileServer(new FileServerOptions()
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")
                ),
            RequestPath = "/index",
            EnableDefaultFiles = true

        }
              ) ;

        app.UseHttpsRedirection();

        app.UseAuthorization();

       

        app.MapControllers();
        #endregion

        app.Run();
    }
}