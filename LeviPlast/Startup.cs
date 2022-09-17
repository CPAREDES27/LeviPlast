using LeviPlast.Core.Interfaces;
using LeviPlast.Core.Utilities;
using LeviPlast.Infraestructure.Data;
using LeviPlast.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LeviPlast
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();            
            services.AddEndpointsApiExplorer();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Servicios Rest - LeviPlast", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAutoMapper(typeof(AutoMapperProfiles));

            services.AddCors(opciones =>
            {
                var urlList = Configuration.GetSection("AllowedOrigin").GetChildren().Select(c => c.Value)
                    .ToArray();
                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(urlList).AllowAnyMethod().AllowAnyHeader();
                });

            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });
        }
    }
}
