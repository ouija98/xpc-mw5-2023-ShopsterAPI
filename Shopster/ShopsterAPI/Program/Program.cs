using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Shopster;
using Shopster.Entities;
using Shopster.Shopster.DAL.AppDbContext;
using Shopster.Shopster.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the builder
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => {options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;}); //added to handle cycles with entities referencing each other in circles in json response
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repository dependency
builder.Services.AddTransient<IRepository<CategoryEntity>, CategoryRepository>();
builder.Services.AddTransient<IRepository<ManufacturerEntity>, ManufacturerRepository>();
builder.Services.AddTransient<IRepository<RatingEntity>, RatingRepository>();
builder.Services.AddTransient<IRepository<CommodityEntity>, CommodityRepository>();


// Add DbContext dependency
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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