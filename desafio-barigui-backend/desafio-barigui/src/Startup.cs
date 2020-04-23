using desafio_barigui.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace desafio_barigui {
  public class Startup {
    private const string FrontEnd = "_myAllowSpecificOrigins";

    public Startup(IConfiguration configuration) {
    }

    public void ConfigureServices(IServiceCollection services) {
      services.AddCors(options => {
        options.AddPolicy(FrontEnd,
          builder => {
            builder.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
          });
      });

      services.AddControllers();

      services.AddDbContext<CostumerContext>(opt =>
        opt.UseInMemoryDatabase("CostumerList"));
      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(FrontEnd);

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}
