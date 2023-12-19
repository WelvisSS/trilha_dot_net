using HabilityCount;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/eduardo/", () => Eduardo.View());
app.MapGet("/matheus>/", () => Matheus.View());
app.MapGet("/giuseppe/", () => Giuseppe.View());
app.MapGet("/welvis/", () => Welvis.View());


app.Run();
