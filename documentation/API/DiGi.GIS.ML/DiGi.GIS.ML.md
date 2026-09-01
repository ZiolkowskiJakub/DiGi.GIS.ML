#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML Namespace
### Classes

<a name='DiGi.GIS.ML.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.PredictedYearBuilts\(this Table\) Method

Scores building feature rows using the machine learning year built prediction model\.

Binds input features by column unique identifier first, with fallback to display names to support both database and tabular formats.

```csharp
public static DiGi.Core.IO.Table.Classes.Table? PredictedYearBuilts(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing building features, including a reference column\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
A new table containing the reference and predicted year built columns, or null if the input table is null or lacks a reference column\.