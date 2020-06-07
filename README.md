# GuidPlus
GuidPlus is extended version of `System.Guid`. Library is compatible with .NET Standard 2.0 and therefore possible to use with .NET Core or .NET Framework implementations. Project uses as little dependencies as possible.

## Why GuidPlus?
When (if possible) there is not enough GUIDs available for a project, GuidPlus creates a chain of standard GUIDs to create more space. It is possible to use GuidPlus to create GUID patterns with prefix GUID, base GUID and suffix GUID, because it accepts `System.Guid[]` in its constructor.

Existing GuidPlus object can be parsed to string, which can be parsed to new GuidPlus object as well.

## Examples
If you want to just generate a GuidPlus value, then use following code. It will create an instance of GuidPlus with length of 3 standard GUIDs.

```csharp
GuidPlus guidPlus = new GuidPlus(3);
```

If you want to generate a GuidPlus value with predefined GUIDs, for example *create two GUIDs chain where one of them is a prefix*, then use following code.

```csharp
Guid prefixGuid = Guid.Parse("6f71a9c8-efef-4c11-acbe-fe8a4a7f1199");
Guid baseGuid = Guid.NewGuid();

GuidPlus guidPlus = new GuidPlus(new Guid[] { prefixGuid, baseGuid });
```

If there is a string representation of GuidPlus object data, then use following code.

```csharp
string guidPlusRepresentation = "6f71a9c8-efef-4c11-acbe-fe8a4a7f1199-82754644-13dc-4449-b98f-1a432d80ef0d";

GuidPlus guidPlus = new GuidPlus(guidPlusRepresentation);
```

To convert GuidPlus object to string, just use `ToString()` method.

```csharp
GuidPlus guidPlus = new GuidPlus(3);

string guidPlusRepresentation = guidPlus.ToString();
```
