using Base.API.ApplicationMapper;
using Base.API.RabbitMQ;
using Base.Repositories;
using Base.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddRepository(Configuration);
builder.Services.AddService(Configuration);
builder.Services.AddScoped<IRabbitMQService,RabbitMQService>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
