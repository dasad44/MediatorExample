using System.Reflection;
using GoogleTagManagerWebApp.Models;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGoogleTagManagerLinkFactory, GoogleTagManagerLinkFactory>();
builder.Services.AddHttpClient<GoogleTagManagerHandler>(nameof(GoogleTagManagerCommand), x =>
{
    x.BaseAddress = new Uri("https://metrics.ceneo.pl");
    x.DefaultRequestHeaders.TryAddWithoutValidation("X-Gtm-Server-Preview", "ZW52LTN8bk5oMHNPcmRWQUR6Z0otc0hkdUEwQXwxN2RmYmQwZmNlOGE2YjFiYTE4OTI=");
    x.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddMediatR(Assembly.GetEntryAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
