using DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using DAL.OrderSystem;
using Metrans.OrderContext;
using Metrans.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(ItemProfile));
builder.Services.AddAutoMapper(typeof(OrderProfile));


var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

optionsBuilder.UseSqlServer(connectionString);

    using (var context = new AppDbContext(optionsBuilder.Options))
    {
        if (!context.Database.CanConnect())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }

builder.Services.AddScoped<IOrderContext, OrderContext>();
builder.Services.AddScoped<IDbCollectionGateway, DbCollectionGateway>();

var host = builder.Build();
var myOrderContext = host.Services.GetService<IOrderContext>();


myOrderContext.ValidateXml();
await myOrderContext.DeserializeAndSaveToDb();



