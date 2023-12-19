using HabilityCount;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/eduardo/", () => Eduardo.View());

app.Run();
