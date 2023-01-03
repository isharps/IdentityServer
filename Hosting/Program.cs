using Hosting.Configuration;
using IdentityServer;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLoaclApiAuthentication();
builder.Services.AddAuthorization()
    .AddAuthorization(configure =>
    {
        configure.AddPolicy("default", p => p.RequireAuthenticatedUser());
    });
builder.Services.AddIdentityServer(o =>
    {
        o.Endpoints.EndpointPathPrefix = "/api/connect";
        o.IssuerUri = "https://www.example.com";
    })
    .AddResourceOwnerCredentialRequestValidator<ResourceOwnerCredentialRequestValidator>()
    .AddExtensionGrantValidator<MyExtensionGrantValidator>()
    .AddProfileService<ProfileService>()
    .AddInMemoryStore(store =>
    {
        store.AddClients(Config.Clients);
        store.AddResources(Config.Resources);
        store.AddSigningCredentials(new X509Certificate2("idsvr.pfx","nbjc"));
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization("default");
app.Run();
