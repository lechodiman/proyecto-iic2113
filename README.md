
# Team 18

## Some good practices

### Commit naming convention

For commits inside branches (other than `develop` and master `master`) , the use of [gitmoji](https://https://gitmoji.carloscuesta.me/) is recommended. For branches `develop` and `master`, only pull requests commits should be present.

### _Gitflow_

This repository uses [_GitFlow_](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow). For any commit to be added to `master` or `develop`, a pull request has to be done. Exceptional _hot fixes_ fall out of this practice.

### Pull requests

Pull request should have meaning titles such as "Add home site to app". Descriptions should start with "This branch will" (and be followed by verbs such as "add", "create", "migrate" or any other).

For merging branches, always use _Squash and merge_, with the exception of `develop` to `master`, where _Merge_ will be used.

### Branch naming contract

All branches in repository must follow the following contract:

```text
branch-type/name-of-branch
```

Where **branch-type** indicates what is the purpose of the branch. The possible values are:

| **`branch-type`** | **description**                                                                                                                                |
| ----------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| feature           | Add a new feature to the main code. Features are client-oriented, meaning no features of code are included here.                               |
| bugfix            | Fix a non-critical part of the code.                                                                                                           |
| improvement       | Improve an already implemented feature. Improvements are also client-oriented.                                                                 |
| library           | Packages and packages versioning oriented. Fixes of code for updating dependencies should be included here.                                    |
| prerelease        | For versioning a code almost ready for it's release. Code here shouldn't add new features, rather freeze new features. For testing pre-release |
| release           | For freezing version these is a final version of the code prior to a release.                                                                  |
| hotfix            | Fixing a critical part of the code or application.                                                                                             |
| docs              | Documenting code or adding documenting files.                                                                                                  |

## Documents

In the `documents` directory are some useful files that represent the data model.


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