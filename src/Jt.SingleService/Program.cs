using Jt.SingleService;

var builder = WebApplication.CreateBuilder(args);

ConfigureService.AddServices(builder);

var app = builder.Build();

ConfigureService.Use(app);

ConfigureService.Run(app);
