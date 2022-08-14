using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCart.API.Middleware;
using ProductCart.Domain.Services;
using ProductCart.Infrastructure.Database;
using ProductCart.Service.Mappings;
using ProductCart.Service.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
var app = builder.Build();
Configure(app, builder.Environment);

static void ConfigureServices(WebApplicationBuilder builder)
{
    IServiceCollection services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c => c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ProductCart.Api", Version = "v1" }));
    services.AddControllers();



    services.AddMediatR(typeof(Program));
    var assembly = AppDomain.CurrentDomain.Load("ProductCart.Data"); 
    services.AddMediatR(assembly);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<PostgreDbContext>(options =>
        options.UseNpgsql(connectionString));

    services.AddSingleton<IConnectionMultiplexer>(x =>
    {
        var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisHost"), true);

        return ConnectionMultiplexer.Connect(configuration);
    });

    services.AddMvc();
    services.AddScoped<ICartService, CartService>();
    services.AddScoped<IProductService, ProductService>();

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

    app.UseMiddleware<CustomExceptionMiddleware>();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}