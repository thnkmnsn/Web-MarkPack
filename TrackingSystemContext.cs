using Microsoft.EntityFrameworkCore;
using MarkPackReport.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<AppBoxProcess> AppBoxProcess { get; set; }
    public DbSet<AppBoxMarkingTracking> AppBoxMarkingTracking { get; set; }
    public DbSet<ViewPackingList> ViewPaackingList { get; set; }
    public DbSet<ViewPackingAndMarkingTracking> ViewPackingAndMarkingTracking { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ViewPackingList>()
            .HasNoKey()
            .ToView("ViewPackingList");

        modelBuilder.Entity<ViewPackingAndMarkingTracking>()
            .HasNoKey()
            .ToView("ViewPackingAndMarkingTracking");

        base.OnModelCreating(modelBuilder);
    }


}