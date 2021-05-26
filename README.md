# Package

Install-Package Dapper.Extensions.NetCore -Version 3.1.5

Install-Package System.Data.SqlClient -Version 4.8.2

Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 3.1.15


# Setting

StartUp >

public void ConfigureServices(IServiceCollection services) { 

   services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
   
}
