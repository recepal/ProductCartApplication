

using AutoMapper;
using MediatR;
using ProductCart.Data.Commands;
using ProductCart.Domain.Services;
using ProductCart.Infrastructure.Database;
using ProductCart.Service.Mappings;
using ProductCart.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
Configure(app, builder.Environment);

static void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c => c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MyProject.Api", Version = "v1" }));
    services.AddControllers();



    services.AddMediatR(typeof(Program));
    services.AddMediatR(typeof(AddProductCommand).GetTypeInfo().Assembly);

    services.AddScoped<ICartService, CartService>();
    services.AddScoped<IProductService, ProductService>();

    services.AddSingleton<PostgreDbContext>();
    services.AddMvc();
   


    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductCard.Service v1");
            c.RoutePrefix = string.Empty;
        });
    }

    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}