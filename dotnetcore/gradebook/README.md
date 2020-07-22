# Gradebook
A simple console application to understand basic concepts of C#. This application demonstrates basic usage of C# language, adding unit tests, solution file.

## Table Of Content
- [Building Application](#building-application)
- [Running Application](#running-application)
- [Unit Tests](#unit-tests)

### Building Application
Navigate to the root folder and execute:
```
$ dotnet build
```
## Running Application
In order to start the application, first build the application using instruction given above. Once the application build process is finished, navigate to the bin folder where the `dll` is stored after compilation, and run the application.
```
$ cd src/GradeBook/bin/Debug/netcoreapp3.1
$ dotnet GradeBook.dll
```
## Unit Tests
Navigate to the root folder and execute:
```
$ dotnet test
```