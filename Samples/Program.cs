using WebServer;

var builder = WebApplication.CreateWebBuilder();
var app = builder.Build();
app.Use((next) => (context) =>
{
    Console.WriteLine("First middleware");
    return next(context);
});
app.Run();  