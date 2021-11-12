using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
  public class WebsiteContext : DbContext
  {
    public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
    {
    }

    public DbSet<WebsiteItem> WebsiteItems { get; set; }
  }
}