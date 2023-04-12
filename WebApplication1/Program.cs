using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Entities;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the builder
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repository dependency
builder.Services.AddTransient<IRepository<CategoryEntity>, CategoryRepository>();
builder.Services.AddTransient<IRepository<ManufacturerEntity>, ManufacturerRepository>();
builder.Services.AddTransient<IRepository<RatingEntity>, RatingRepository>();
builder.Services.AddTransient<IRepository<CommodityEntity>, CommodityRepository>();


// Add DbContext dependency
builder.Services.AddDbContext<Database>(options =>
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