Connection String:  https://learn.microsoft.com/en-us/answers/questions/906488/read-appconfig-values-in-net-6-console.html
  https://www.connectionstrings.com/postgresql/

Migration : https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx

Ef core YT video: https://www.youtube.com/watch?v=PqFwtF9HE3Y&t=2250s

Postgres+EF core: https://www.npgsql.org/efcore/
    https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration

install dotnet tool for EF(not built in dotnet Have to install explicitly): 
  https://www.nuget.org/packages/dotnet-ef/#versions-tab
  dotnet tool install --global dotnet-ef --version 6.0.10

  Add migration : dotnet ef migrations add "Initial Migration"
  Update Database : dotnet ef database update

  MVC YT video link : https://youtu.be/2Cp8Ti_f9Gk

Date time eror occured: (For postgres not for Sql server) Cannot write DateTime with Kind=Unspecified to PostgreSQL type 'timestamp with time zone', only UTC is supported. Solution: Add below code to program.cs
  AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);