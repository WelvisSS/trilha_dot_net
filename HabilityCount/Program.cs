using Roadmap_ASP_NET_CORE;

//Onde tiver DevName, substitua pelo seu nome;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/Giuseppe/", () => Giuseppe.View());

app.Run();
