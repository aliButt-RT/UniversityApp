using UniversityApp;

var builder = WebApplication.CreateBuilder(args);

// Add startup object

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app,builder.Environment);

