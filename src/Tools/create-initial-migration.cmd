@echo off
dotnet-ef migrations -p Topelab.RegisterActivity.Adapters\Topelab.RegisterActivity.Adapters.csproj -s Topelab.RegisterActivity.Tools\Topelab.RegisterActivity.Tools.csproj add InitialCreate
