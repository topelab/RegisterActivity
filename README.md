# Introduction

RegisterActiviy is a small application designed to record the time spent on each of the open applications while you work on your PC. As time passes, the title of the window, the name of the executable, the initial and final time that the application has been in the foreground are recorded.

# First steps

## Build solution

Simply open the solution with Visual Studio 2022 and build it. The main project is *RegisterActity*, it is the one that should be executed.

## Adjust settings

The application is configured through the *appsettings.json* file, whose main keys are "ConnectionStrings:localserver", "OutputDirectory" and "OutputFileName"

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "localserver": "Data Source=data\\ActivitiesDB.db;"
  },
  "OutputDirectory": "C:\\Data\\RegisterActivity",
  "OutputFileName": "ActivitiesDB",
  "EPPlus": {
    "ExcelPackage": {
      "LicenseContext": "NonCommercial"
    }
  }
}
```

- **ConnectionStrings:localserver**: You must indicate a connection string for SQLite, it can be relative to the folder where *RegisterActivity* is executed
- **OutputDirectory**: Indicates the path where the data that we export will be saved
- **OutputFileName**: Indicates the name of the file that will be used when exporting (without extension)
