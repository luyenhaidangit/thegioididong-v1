using Demo.Data.Infrastructure;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Data.Repositories;
using Thegioididong.Service;
using Thegioididong.Service.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations();
});

builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategorytRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<ISlideService, SlideService>();
builder.Services.AddTransient<ISlideRepository, SlideRepository>();
builder.Services.AddTransient<IStorageService, FileStorageService>();

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
