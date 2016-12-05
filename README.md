# 04-Practices-.NET-Core
Sample program of .NET Core

Most of the materials are from https://docs.microsoft.com/en-us/aspnet/core

To update EF database
- If Data/Migrations folder is not empty, delete all files inside this folder
- Stop IIS Express
- Shift + right click on folder i.e Controller
- Open command window
- Type 'cd ..'
- Type 'dotnet ef migrations add Initial'
- Type 'dotnet ef database update'
- Re-run the application
