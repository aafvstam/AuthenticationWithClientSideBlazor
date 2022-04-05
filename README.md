# AuthenticationWithClientSideBlazor

Inspired by the blog post by Chris Sainty:
https://chrissainty.com/securing-your-blazor-apps-authentication-with-clientside-blazor-using-webapi-aspnet-core-identity/

Rewrite for Blazor .NET Core 6+

This solution can run on SQLite or SQL Server
To switch comment/uncomment the proper sections in Program.cs (Server) and appsettings.json (Server)

Initialize databases after switching:
First delete the Migrations as this contains database specific instructions for either SQLite or SQL Server

You generate the right Migrations files by running
Add-Migration CreateIdentitySchema -o Data/Migrations

Create databases by running:
Update-Database