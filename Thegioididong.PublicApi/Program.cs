using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Demo.Data.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Data.Repositories;
using Thegioididong.PublicApi.Modules;
using Thegioididong.Service;
using Thegioididong.Service.Common;
using Thegioididong.Service.Plugins;
using static Thegioididong.Common.Constants.SystemConstant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen(c =>
////{
////    c.DocumentFilter<SwaggerModule>();
////});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

//builder.Services.AddSwaggerGen(config =>
//{
//    config.DocumentFilter<SwaggerModule>();

//    config.EnableAnnotations();

//    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
//                      Enter 'Bearer' [space] and then your token in the text input below.
//                      \r\n\r\nExample: 'Bearer 12345abcdef'",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer"
//    });

//    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                },
//                Scheme = "oauth2",
//                Name = "Bearer",
//                In = ParameterLocation.Header,
//            },
//            new List<string>()
//        }
//    });
//});


//// Config authenciation

//var key = Encoding.ASCII.GetBytes(SecretConfiguration.SecretKey);
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(config =>
{
    config.DocumentFilter<SwaggerModule>();

    config.EnableAnnotations();

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


// Config authenciation
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var key = Encoding.ASCII.GetBytes(SecretConfiguration.SecretKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddHttpClient();


// Config authenciation



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


//var app = builder.Build();

//app.UseCors(x => x
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader());

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}



//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.UseAuthentication();

//app.MapControllers();

//app.Run();

var app = builder.Build();
app.UseStaticFiles();
app.UseDirectoryBrowser();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
