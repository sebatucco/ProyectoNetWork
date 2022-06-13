

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRegistrationService(builder);




var app = builder.Build();

//configure
app.AddRegistrationBuilder();
app.Run();
