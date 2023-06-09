using Microsoft.EntityFrameworkCore;
using Shopster.DAL;
using Shopster.DAL.Entities;
using Shopster.DAL.Repositories;
using Shopster.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the builder
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers();

//Mapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repository dependency
builder.Services.AddTransient<IRepository<CategoryEntity>, CategoryRepository>();
builder.Services.AddTransient<IRepository<ManufacturerEntity>, ManufacturerRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<ICommodityRepository, CommodityRepository>();


// Add DbContext dependency
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Shopster.API")));

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

public partial class Program { }