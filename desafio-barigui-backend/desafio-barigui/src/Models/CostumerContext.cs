using Microsoft.EntityFrameworkCore;

namespace desafio_barigui.Models {
  public class CostumerContext : DbContext {
    public CostumerContext(DbContextOptions<CostumerContext> options)
      : base(options) {
    }

    public DbSet<CostumerItem> CostumerItems { get; set; }
  }
}
