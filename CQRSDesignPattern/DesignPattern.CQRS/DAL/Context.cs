using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = MURATBODUR; Database = CQRS; User Id = sa; Password = 2697; Trusted_Connection = True; MultipleActiveResultSets = true; Integrated Security = true;");

		}


		public DbSet<Product> Products { get; set; }	
	}
}
