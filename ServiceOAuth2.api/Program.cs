using ServiceOAuth2.business.Interfaces;
using ServiceOAuth2.business.Services;
using ServiceOAuth2.data.Interfaces;
using ServiceOAuth2.data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IAccessTokensService, AccessTokensService>();
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();
builder.Services.AddTransient<IAuthorizationTokensService, AuthorizationTokensService>();
builder.Services.AddTransient<IClientApplicationsService, ClientApplicationsService>();
builder.Services.AddTransient<IPermissionsService, PermissionsService>();
builder.Services.AddTransient<IScopesService, ScopesService>();
builder.Services.AddTransient<IUsersService, UsersService>();



builder.Services.AddTransient<IBaseRepository, AccessTokensRepository>();
builder.Services.AddTransient<IBaseRepository, AuthorizationTokensRepository>();
builder.Services.AddTransient<IBaseRepository, BaseRepository>();
builder.Services.AddTransient<IBaseRepository, ClientApplicationsRepository>();
builder.Services.AddTransient<IBaseRepository, PermissionsRepository>();
builder.Services.AddTransient<IBaseRepository, ScopesRepository>();
builder.Services.AddTransient<IBaseRepository, UsersRepository>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
