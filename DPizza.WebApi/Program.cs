using DPizza.Application;
using DPizza.Application.Interfaces;
using DPizza.Infrastructure.AutoMapper;
using DPizza.Infrastructure.FileManager;
using DPizza.Infrastructure.FileManager.Contexts;
using DPizza.Infrastructure.Identity;
using DPizza.Infrastructure.Identity.Contexts;
using DPizza.Infrastructure.Identity.Models;
using DPizza.Infrastructure.Identity.Seeds;
using DPizza.Infrastructure.Persistence;
using DPizza.Infrastructure.Persistence.Contexts;
using DPizza.Infrastructure.Persistence.Seeds;
using DPizza.Infrastructure.Resources;
using DPizza.WebApi.Infrastracture.Extensions;
using DPizza.WebApi.Infrastracture.Middlewares;
using DPizza.WebApi.Infrastracture.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection; 


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddFileManagerInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddResourcesInfrastructure(builder.Configuration);

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddJwt(builder.Configuration);

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.AddSwaggerWithVersioning();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Any", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();

    });
});
builder.Services.AddCustomLocalization(builder.Configuration);

builder.Services.AddHealthChecks();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

builder.Services.AddAutoMapper(typeof(MapperProfile)); //auto mapper

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
    await services.GetRequiredService<DPizzaContext>().Database.MigrateAsync();
    await services.GetRequiredService<FileManagerDbContext>().Database.MigrateAsync();

    //Seed Data
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());
    await BranchDetailData.SeedAsync(services.GetRequiredService<DPizzaContext>());
}

//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DPizza.WebApi v1"));
//}

app.UseCustomLocalization();
app.UseCors("Any");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");

app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();