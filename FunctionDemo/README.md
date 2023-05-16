Microsoft.EntityFrameworkCore 
Microsoft.EntityFrameworkCore.Design 
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

dotnet ef dbcontext scaffold "Server=<server_name>;Database=<database_name>;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models

Scaffold-DbContext "Server=tcp:172.16.39.7,1433;Initial Catalog=SmartHotel;MultipleActiveResultSets=true;User ID=sa;Password=@Angela2000@" Microsoft.EntityFrameworkCore.SqlServer -o Models

Scaffold-DbContext "Server=tcp:172.16.39.7,1433;Initial Catalog=SmartHotel;MultipleActiveResultSets=true;User ID=sa;Password=@Angela2000@;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Repository/Models  -context dbDataContext -contextDir Repository -DataAnnotations -f