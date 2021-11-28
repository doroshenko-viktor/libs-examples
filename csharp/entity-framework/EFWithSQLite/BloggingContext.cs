using Microsoft.EntityFrameworkCore;

namespace EFWithSQLite;

public class BloggingContext : DbContext
{
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }

    public string DbPath { get; private set; }

    public BloggingContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = $"{path}{Path.DirectorySeparatorChar}blogging.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}