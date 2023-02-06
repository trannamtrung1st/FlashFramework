using FlashFramework.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;

var moduleAssemblies = services.LoadModules(configuration);

services.AddRazorPages()
    .ConfigureApplicationPartManager(apm =>
    {
        foreach (var assembly in moduleAssemblies)
        {
            var part = new AssemblyPart(assembly);
            var compiledPart = new CompiledRazorAssemblyPart(assembly);
            apm.ApplicationParts.Add(part);
            apm.ApplicationParts.Add(compiledPart);
        }
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
