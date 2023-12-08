using AjCorpWebApp.Data;
using AjCorpWebApp.Servicos;
using AjCorpWebApp.Servicos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AjCorpWebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
         
        // Add services to the container.
        builder.Services.AddRazorPages(options => {
            options.Conventions.AuthorizeFolder("/Marcas");
		});

        builder.Services.AddTransient<IProdutoServico, ProdutoServico>();
        builder.Services.AddDbContext<ProdutoDbContext>();

        builder.Services.AddDefaultIdentity<IdentityUser>(options 
            => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ProdutoDbContext>();

        builder.Services.Configure<IdentityOptions>(options => {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            
            options.Lockout.MaxFailedAccessAttempts = 20;
            options.Lockout.AllowedForNewUsers = true;

            options.User.RequireUniqueEmail = true;
        });
        

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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}