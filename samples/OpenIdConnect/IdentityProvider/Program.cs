using IdentityProvider.IdentityServer;
using IdentityProvider.IdentityServer.Services;
using IdentityProvider.IdentityServer.Validators;
using IdentityServer.Hosting;
using IdentityServer.Hosting.DependencyInjection;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(IdentityServerConfig.Clients)
    .AddInMemoryResources(IdentityServerConfig.Resources)
    .AddProfileService<ProfileService>()
    .AddInMemoryDeveloperSigningCredentials()
    .AddResourceOwnerCredentialRequestValidator<ResourceOwnerCredentialRequestValidator>();
//��֤����
builder.Services.AddAuthentication(configureOptions =>
{
    //ʹ��identityserver��ΪĬ�ϵ���֤����
    configureOptions.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
    //ʹ��cookie��ΪĬ�ϵ���ս����
    configureOptions.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    //���cookie��֤����
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    //���identityserver��֤����
    .AddIdentityServer(IdentityServerAuthenticationDefaults.AuthenticationScheme);
//��Ȩ����
builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("default", p =>
    {
        p.RequireClaim(JwtClaimTypes.Subject);
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIdentityServer();
app.UseHttpsRedirection();
//������֤
app.UseAuthentication();
//������Ȩ
app.UseAuthorization();

app.MapDefaultControllerRoute()
    //Ϊ���п��������Ĭ�ϵ���Ȩ����
    .RequireAuthorization("default");

app.Run();
