using API.Configs.Context;
using API.Configs.Profile;
using API.Configs.Repository;
using API.Configs.Service;
using API.Configs.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddRepositories();

builder.Services.AddProfiles();

builder.Services.AddProfiles();

builder.Services.AddContext();

builder.Services.AddValidators();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("FrontCors", builder =>
    {
        builder.WithOrigins("http://localhost:4200");
        builder.WithMethods("GET","POST","PUT","DELETE");
        builder.WithHeaders("Content-Type");
    });
});

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

app.UseHttpsRedirection();

app.UseCors("FrontCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
