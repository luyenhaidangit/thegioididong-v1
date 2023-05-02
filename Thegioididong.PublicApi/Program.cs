using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Demo.Data.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Data.Repositories;
using Thegioididong.PublicApi.Modules;
using Thegioididong.Service;
using Thegioididong.Service.Common;
using Thegioididong.Service.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.DocumentFilter<SwaggerModule>();
});

builder.Services.AddHttpClient();


// Config authenciation
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));


//builder.Services.AddTransient<IProductCategoryRepository, ProductCategorytRepository>();
//builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
//builder.Services.AddTransient<ISlideService, SlideService>();
//builder.Services.AddTransient<ISlideRepository, SlideRepository>();
//builder.Services.AddTransient<IStorageService, FileStorageService>();
//builder.Services.AddTransient<ISearchRepository, SearchRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IProductService, ProductService>();
//builder.Services.AddTransient<ISearchService, SearchService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
