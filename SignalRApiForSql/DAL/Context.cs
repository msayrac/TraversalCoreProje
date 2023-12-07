using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SignalRApiForSql.DAL
{
	public class Context:DbContext
	{

		//public Context(DbContextOptions<Context> options) : base(options)
		//{


		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.;database=TraversalSignalDB; TrustServerCertificate=True; integrated security=true;");
		}

		public DbSet<Visitor> Visitors { get; set; }




	}
}
