using AuthGuardPro;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StayEasePro_Domain.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register controllers with the dependency injection (DI) container
builder.Services.AddControllers();

// Add support for API documentation and discovery with Swagger
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger to include JWT Bearer authentication
builder.Services.AddSwaggerGen(options =>
{
    // Define API documentation with version information
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Define JWT Bearer security scheme for authentication in Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization", // Name of the header for the JWT
        Type = SecuritySchemeType.Http, // Define type as HTTP for JWT
        Scheme = "bearer", // Specify the "bearer" scheme
        BearerFormat = "JWT", // Format to clarify that the token is a JWT
        In = ParameterLocation.Header, // Location of token: in request header
        Description = "Enter 'Bearer' [space] and then your token in the text input below.\nExample: 'Bearer eyJhbGciOiJIUzI1NiIs...'"
    });

    // Enforce the JWT Bearer authentication requirement globally for Swagger
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme, // Referencing security scheme defined above
                    Id = "Bearer"
                }
            },
            new string[] {} // Empty array indicates all endpoints require JWT Bearer authentication
        }
    });
});

// Register the database context (UsersContext) with dependency injection
builder.Services.AddDbContext<StayeaseproContext>(options =>
{
    // Set up SQL Server with a connection string from app settings
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register dependencies for DI configured in an external AllDI method
builder.Services.AllDI();

// Retrieve JWT settings from configuration (e.g., appsettings.json)
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// Configure JWT Bearer authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Set default authentication scheme to JWT Bearer
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Set default challenge scheme to JWT Bearer
})
.AddJwtBearer(options =>
{
    // Define token validation parameters
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Ensure token issuer matches
        ValidateAudience = true, // Ensure token audience matches
        ValidateLifetime = true, // Validate token expiration
        ValidateIssuerSigningKey = true, // Validate the signing key used for the token
        ValidIssuer = jwtSettings["Issuer"], // Expected issuer from JWT settings
        ValidAudience = jwtSettings["Audience"], // Expected audience from JWT settings
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"])) // Symmetric key for token encryption
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger and Swagger UI for API documentation in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Force HTTPS redirection for all requests
app.UseHttpsRedirection();

// Enable the configured authentication middleware
app.UseAuthentication();

// Enable the configured authorization middleware
app.UseAuthorization();

// Map controllers to handle incoming requests
app.MapControllers();

app.UseMiddleware<CustomAuthorizeUserMiddleware>();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
// Run the application
app.Run();
