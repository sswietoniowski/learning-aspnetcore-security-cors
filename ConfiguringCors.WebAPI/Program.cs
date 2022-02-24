using ConfiguringCors.Application;
using ConfiguringCors.Application.Contracts.Infrastructure;
using ConfiguringCors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureApplicationServices();
builder.Services.AddScoped<IUserGenerator, BogusUserGenerator>();
builder.Services.AddScoped<IUsersService, UsersService>();


var allowedOrigins = builder.Configuration.GetValue<string>("Cors:AllowedOrigins")?.Split(",") ?? new string[0];
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin();
    });
    options.AddPolicy("WithOrigins", builder =>
    {
        builder
            .WithOrigins(allowedOrigins)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
    options.AddPolicy("WithOriginsMethodsdHeaders", builder =>
    {
        builder
            .WithOrigins(allowedOrigins)
            .WithMethods("Get")
            .WithHeaders("Content-Type:");
    });
});

builder.Services.AddControllers();
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

// if we would like to define this policy as the default, we could write
//app.UseCors("AllowAnyOrigin");
// but to test and show different strategies we woudl apply CORS policies
// per a concrete endpoint
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
