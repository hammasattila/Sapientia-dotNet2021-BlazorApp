# .NET Blazor Application

During **.NET Technologies** course we developed a simple Blazor Application in which we learnd the basics, like NuGet Packages, how to create pages, fetch data from an API, or how to manage databases inside a .NET project.

## Compiling and running the app

You have to insert your API key into the **App.config** file found in the **Blazor Application project**, so your configuration file should look like this:

```XML
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="BaseUrl" value="https://api.themoviedb.org/3" />
    <add key="ApiKey" value="1d92fq35390e7f3e169b9b47420bftfs" /> <!-- Your API key here. -->
  </appSettings>
</configuration>
```

You can obtain this key by creating an account at [The Movie Database](https://www.themoviedb.org/signup) and after that [generate](https://www.themoviedb.org/settings/api) your API key.

## References

- [Icons](https://useiconic.com/open) used in the application
- For creating modal in the application [Blazored modal](https://github.com/Blazored/Modal) was used.
- Database management was done by following [Bekenty J. Baptiste's tutorial](http://bekenty.com/use-sqlite-in-net-core-3-with-entity-framework-core/).

## Useful commands

Packages needed for manageing the SQLite database:

```PowerShell
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```

Generating the SQLite database from a class:

```PowerShell
Add-Migration InitialCreate
Update-Database
```
