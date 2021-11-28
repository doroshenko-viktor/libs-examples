# Entity Framework Core

Made by official Microsoft tutorial

Create dependency to `Microsoft.EntityFrameworkCore.Sqlite`.

To create migrations:

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## References

[source](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
