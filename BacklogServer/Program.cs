using BacklogServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// swagger
builder.Services.AddEndpointsApiExplorer(); // service for documenting routes
// builder.Services.AddSwaggerGen(); // service for generating json focument

// builder.Services.AddSingleton<ILogger, Logger>();
// builder.Services.AddScoped<ILogger, Logger>();
// builder.Services.AddTransient<ILogger, Logger>();

// builder.Services.AddAuthentication();
// builder.Services.AddAuthorization();
builder.Services.AddDbContext<BacklogAppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.UseAuthentication();
// app.UseAuthorization();

// if(app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUi();
// }

app.UseRouting();
app.MapControllers();

app.Run();
