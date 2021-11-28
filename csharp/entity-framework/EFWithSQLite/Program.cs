using EFWithSQLite;
using static System.Console;

using (var db = new BloggingContext())
{
    // Note: This sample requires the database to be created before running.
    WriteLine($"Database path: {db.DbPath}.");

    // Create
    WriteLine("Inserting a new blog");
    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
    db.SaveChanges();

    // Read
    WriteLine("Querying for a blog");
    var blog = db.Blogs?
        .OrderBy(b => b.BlogId)
        .First();

    // Update
    WriteLine("Updating the blog and adding a post");
    if (blog is not null)
    {
        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(
            new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
        db.SaveChanges();

        // Delete
        WriteLine("Delete the blog");
        db.Remove(blog);
        db.SaveChanges();
    }
    else
    {
        WriteLine("Blog not found");
    }
}