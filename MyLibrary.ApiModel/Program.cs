using Microsoft.EntityFrameworkCore;
using MyLibrary.ApiModel.Controllers;
using MyLibrary.DbModel.Context;
using MyLibrary.JsonRepositoryModel.Context;
using MyLibrary.JsonRepositoryModel.Repositories;
using MyLibrary.JsonRepositoryModel.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext options
builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlDbContext"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql")));

// Register JsonDbContext
builder.Services.AddScoped<JsonDbContext>(sp =>
{
    var dataFolderPath = builder.Configuration["DataFolderPath"];
    return new JsonDbContext(dataFolderPath);
});

// Register Repositories for JsonDbContext
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
builder.Services.AddScoped<IBookCopyRepository, BookCopyRepository>();
builder.Services.AddScoped<IBookThemeRepository, BookThemeRepository>();
builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MyLibrary API",
        Version = "v1",
        Description = "API for MyLibrary with CRUD and custom queries"
    });
});

// Configure CORS to allow all origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyLibrary API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
