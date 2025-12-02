# FiyiStackDeskApp

**Low-code generator / desktop base application**

## 📄 Overview

FiyiStackDeskApp is a desktop application built in C#/.NET designed as a low-code generator: a base environment that allows you to quickly create and extend web and desktop solutions with minimal effort.

FiyiStackDeskApp lets you quickly create CRUD applications by entering an ERD into this system. This low-code generator and catalyst allows you to create the web and desktop views to manipulate a database table.

If a typical application requires 10,000 lines of code, FiyiStackDeskApp generates 7,000. For each table in a database, FiyiStackDeskApp generates at least 5,000 lines of code to make your CRUD application functional.

## 📄 CRUD Functionalities:
- Add and modify data, provided it passes the tests available in the entity.
- Display data in table or chart format.
- Export data to PDF, Excel, and CSV formats.
- Import data from an Excel file.
- Bulk actions for copying and deleting.

## 🗂 Repository Structure
FiyiStackDeskApp
├── .gitignore
├── FiyiStackDeskApp.sln
├── LICENSE
├── FiyiStackDeskApp
    ├── (project source code)
    └── DatabaseBackup/
        ├── FiyiStackDeskApp.bak
        └── CommonFunctions.sql
        
## 🚀 How to build and run

Follow these steps to run the application locally:

1. Clone the repository  
   ```bash
   git clone https://github.com/fiyistack/FiyiStackDeskApp.git
2. Do a backup of the database FiyiStackDeskApp.bak with Microsoft SQL Server Studio or another similar.
4. Execute the file FiyiStackDeskApp.sln with Visual Studio.
5. Restore NuGet packages.
6. If you want to debug, put a breakpoint in the startup file, Program.cs
7. Put my credentials to use it: USER: novillo.matias1@gmail.com, PASSWORD: z
8. Create a new project
9. Restore SQL Common Functions from DatabaseBackup/ folder
10. Create a DB connection
11. Create a table inside that DB
12. Generate

## Generators in operation:
G1, generates in: .NET ecosystem, C#, Blazor, MS SQL Server, EF Core, DI, Repository pattern, DDD, Bootstrap, Js, CSS, HTML
