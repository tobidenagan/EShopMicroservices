var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

var app = builder.Build();

//Configure the HTTO request pipeline,

app.Run();
