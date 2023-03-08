using Jt.SingleService;

var builder = WebApplication.CreateBuilder(args);

StartUp.AddServices(builder.Services);

var app = builder.Build();

StartUp.Use(app);

StartUp.Run(app);
