using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Abbott Weather API", 
        Version = "v1",
        Description = "Demo API for Abbott's API modernization initiative - showcasing automated CI/CD pipeline",
        Contact = new OpenApiContact
        {
            Name = "Abbott API Team",
            Email = "api-team@abbott.com"
        }
    });
});

// Add health checks
builder.Services.AddHealthChecks();

// Add CORS for demo purposes
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Abbott Weather API v1");
        c.RoutePrefix = "swagger";
        c.DocumentTitle = "Abbott API Demo";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

// Map health check endpoint
app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
