using Microsoft.EntityFrameworkCore;
using task_Auth.Models;

namespace task_Auth.Data
{
	public class ApplicationDbContext :DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}
		public DbSet<User> Users { get; set; }
	}
}
