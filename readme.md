# This Fork
This fork adds support for typings of Knockout form.
This involves returning classes where the type is KnocoutObservable<T> or KnockoutObservableArray<T>

Example result:


```
#!typescript

declare module ServerTypings.ModelConn {
	interface IInvoicesView {
		Id: KnockoutObservable<number>;
		IdStr: KnockoutObservable<string>;
		InvoiceNo: KnockoutObservable<number>;
		InvoiceNoStr: KnockoutObservable<string>;
		InvoiceDate: KnockoutObservable<Date>;
		OptShowPaymentMethod: KnockoutObservable<boolean>;
		InvoiceLinesView: KockoutObservableArray<ServerTypings.ModelConn.IInvoiceLinesView>;
   }
}
```
# The TsKnockoutModelGenerator
Applying the Knockoutformatter is simple..
Just replace the 
```
#!c#

TypeScript.Definitions()
```
 clause in the **.tt** file with T
```
#!c#

ypeScript.Definitions(new TypeLite.AlternateGenerators.TsKnockoutModelGenerator()) 
```

and you are all done.


# TypeLITE

TypeLITE is the utility, that generates [TypeScript](http://www.typescriptlang.org/) definitions from .NET classes. 

It's especially useful to keep your [TypeScript](http://www.typescriptlang.org/) classes on the client in sync with your POCO classes on the server.

## Usage

Please check [the project webpage](http://type.litesolutions.net/)

## License

The library is distributed under MIT license.

## Changelog

### Version 1.1.2.0		(3. 4. 2015)
Fixed		#85 Unable to reuse enums
Fixed       #84 Module name formatter doesn't work for nested namespaces

### Version 1.1.1.0		(1. 3. 2015)
Fixed		#76 Error when renaming modules

### Version 1.1.0.0		(12. 2. 2015)
Added		Better extensibility of TsGenerator, better extensibility of formaters

### Version 1.0.2.0		(17. 11. 2014)
Fixed		#47 Fixed problem with derived generics

### Version 1.0.1.0		(17. 11. 2014)
Fixed		#64 Incorrect definition for KeyValuePair<int, List<string>>
Fixed		#65 Generic porperty referencin containing type causes StackOverflowException
Added		#49 Better output formating


### Version 1.0.0.0		(29. 10. 2014)
Fixed		#57 Support for generics

### Version 0.9.6.0		(20. 10. 2014)
Fixed		#51 Support for multidimensional arrays

### Version 0.9.5.0		(5. 9. 2014)
Fixed		#52 Support for using [TsEnum] without class
Added		#60 DateTimeOffset generated as Date
Added		#50 Support for generating TypeScript interfaces from .NET interfaces

### Version 0.9.4.1		(3. 9. 2014)
Fixed		#59 Bug in tt files

### Version 0.9.4.0		(20. 8. 2014)
Added		#57 Support public fields

### Version 0.9.3.0		(18. 6. 2014)
Fixed		#48 For<Enum>().ToModule()
Added		#46 Support for inner classes

### Version 0.9.2.0		(16. 6. 2014)
Fixed		#43 Declare keyword on modules with enums
Fixed		#44 Export keyword on enums
Fixed		#45 Empty modules
Added		#27 Support for standalone enums

### Version 0.9.1.9		(10. 6. 2014)
Fixed		#33: Enums not created when using list
Fixed		#41: Combination of generics <T> and Enum throws an exception
Fixed		#42: Duplicate TS iterfaces for generic parameters

### Version 0.9.1.8		(8. 6. 2014)
Added		Strong assembly names

### Version 0.9.1.7		(29. 5. 2014)
Added		#17: Enums should go to .ts files

### Version 0.9.1.6		(17. 1. 2014)
Added		MemberTypeFormatter
Fixed		#28: Fluent method for adding references

### Version 0.9.1.5		(10. 11. 2013)
Added		Optional fields
Fixed		#24: Nullable enums

### Version 0.9.1.4		(14. 10. 2013)
Added		Nuget package TypeLITE.Lib without T4 templates
Fixed		Empty modules when type convertor is used

### Version 0.9.1.3		(10. 10. 2013)
Fixed		Incorrect output of type convertor if the module is specified

### Version 0.9.1.2		(9. 10. 2013)
Fixed		#15: Problems with enum underlaying types
Fixed		#18: ModelVisitor visits enums
Added		#7:  Type convertors
Added		#9:  Fluent configuration for classes

### Version 0.9.1.1		(9. 8. 2013)
Added		#12: Generation of enums

### Version 0.9.1beta      	(9. 8. 2013)
Fixed		#13: TypeScript 0.9.1 uses boolean keyword instead of bool

### Version 0.9.0beta	(27. 6. 2013)
Fixed		#11: Typescript 0.9 requires declare keyword in the module definition
Enhancement	#10: Converted project to Portable class library

### Version 0.8.3		(22. 4. 2013)
Fixed		#4: DateTime type conversion results in invalid type definition
Fixed		#5: Generic classes result in invalid interface definitions
Fixed		#6: Properties with System.Guid type result in invalid typescript code	 

### Version 0.8.2		(8. 4. 2013)
Fixed		#2: TsIgnore-attribute doesn't work with properties
Added		Support for nullable value types
Added		Support for .NET 4