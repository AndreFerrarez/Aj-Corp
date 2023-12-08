using AjCorpWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AjCorpWebApp.Data;

public class ProdutoDbContext : IdentityDbContext
{
    public DbSet<Produto> Produto { get; set; }
	public DbSet<Marca> Marca { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory()) 
			.AddJsonFile("appsettings.json")
			.Build();
		string conn = config.GetConnectionString("conn"); 
		
		optionsBuilder.UseSqlServer(conn);
	}
}
