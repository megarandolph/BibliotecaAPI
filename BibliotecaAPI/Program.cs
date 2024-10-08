using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using BibliotecaAPI.Models;
using System.Globalization;
using BibliotecaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
            policy =>
            {
                policy.WithOrigins("https://example.com") // Permitir solo este origen específico
                      .AllowAnyHeader() // Permitir cualquier encabezado
                      .AllowAnyMethod(); // Permitir cualquier método (GET, POST, etc.)
            });

    // Si necesitas permitir todos los orígenes (útil para desarrollo)
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var secretKey = builder.Configuration["JwtSettings:SecretKey"];
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true, // Validar el emisor
           ValidateAudience = true, // Validar la audiencia
           ValidateLifetime = true, // Validar la expiración del token
           ValidateIssuerSigningKey = true, // Validar la clave de firma
           ValidIssuer = "BibliotecaFront", // Emisor válido
           ValidAudience = "BibliotecaApi", // Audiencia válida
           IssuerSigningKey = key // Clave secreta para firmar los tokens
       };
   });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configuración de seguridad para el Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el JWT con el prefijo Bearer. Ejemplo: 'Bearer {token}'"
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
                new string[] {}
            }
        });
});



builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("BibliotecaConnection");
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAutorServices, AutorServices>();
builder.Services.AddScoped<ICategoriaServices, CategoriaServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
builder.Services.AddScoped<ILibroServices, LibroServices>();


var app = builder.Build();


app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
