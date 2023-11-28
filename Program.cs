using AjCorpWebApp.Data;
using AjCorpWebApp.Servicos;
using AjCorpWebApp.Servicos.Data;
using Microsoft.EntityFrameworkCore;

namespace AjCorpWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
       
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddTransient<IProdutoServico, ProdutoServico>();
        builder.Services.AddDbContext<ProdutoDbContext>();

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var context = new ProdutoDbContext();
        context.Database.Migrate();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}