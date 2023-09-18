using Microsoft.EntityFrameworkCore;
using WebBlazorDocsLP.Shared;

namespace WebBlazorDocsLP.Server.Data
{
	public class DataContext : DbContext 
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{

		}
		public DbSet<SistemasDists> Sistemas { get; set; }
	}
}
