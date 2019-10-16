# proyecto-iic2113
Proyecto Diseño Detallado de Software
Apuntes por Luis Chodiman

# Ayudantía 3

Creamos un archivo models **Conference** y otro para **Sponsors** 

    namespace TestAplicationModels { 
    	public class Conference { 
    		public int Id {get; set} //reserved 
    		public string Name {get; set;} 
    		public string Description {get; set;} 
    		public IEnumerable<Sponsor> Sponsors {get; set;} 
    	} 
    } 
    
    namespace TestAplicationModels { 
    	public class Sponsors { 
    		public string Name {get; set;} 
    		public string Description {get; set;}
    	}
    }

Para trabajar con la db Data/ApplicationDbContext.cs 

Public DbSet<tipoObjeto> Nombre de la tabla 

Definimos atributos de la clase 

    Public DbSet<Conference> Conferences {get; set;} 
    
    Public DbSet<Sponsor> Sponsors {get; set;}

Luego en terminal 

    dotnet ef migrations add <MigrationName> 

    dotnet ef database update

Se genera un archivo nuevo en la carpeta de migrations

Se genera una query de creación de tablas relaciones N a N son tebeos con tablas intermedias.

# Dotnet CLI

- List available migrations

    dotnet ef migrations list

- Remove the last migration

    dotnet ef migrations remove

- Drop the database

    dotnet ef database drop

- List available DbContext types

    dotnet ef dbcontext list

- Get information about a DbContext type

    dotnet ef dbcontextinfo

- Scaffolds a DbContext and entity types for a database

    dotnet ef dbcontext scaffold

# Dotnet aspnet-codegenerator

List available migrations

    dotnet aspnet-codegenerator controller -name <Name> -m <ModelName> -dc <DbContext to use> -outDir <Relative output to create the views>
