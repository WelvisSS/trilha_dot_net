using HabilityCount;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Sum.View());
app.MapGet("/eduardo/", () => Eduardo.View());
app.MapGet("/matheus>/", () => Matheus.View());
app.MapGet("/giuseppe/", () => Giuseppe.View());
app.MapGet("/welvis/", () => Welvis.View());
app.MapGet("/wilton/", () => Wilton.View());

app.Run();
