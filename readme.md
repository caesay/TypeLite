# TypeLITE

TypeLITE is the utility, that generates [TypeScript](http://www.typescriptlang.org/) definitions from .NET classes. 

It's especially useful to keep your [TypeScript](http://www.typescriptlang.org/) classes on the client in sync with your POCO classes on the server.

## Usage

1. Download and install [TypeLITE Nuget package](https://nuget.org/packages/TypeLite/0.8.0)
2. Edit TypeLite.tt file - add reference to the assembly with your POCO classes and specify classes you want to be included in the generated file

```
#!c#

TypeScript.GenerateDefinitions().Include<Employee>().Include<Company>()
```

3. Generate TypeScript definitions for specified classes - right-click to the TypeLite.tt in the Solution Explorer and select Run Custom Tool.

## License

The library is distributed under MIT license.