#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML\.Classes Namespace
### Classes

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor'></a>

## YearBuiltPredictor Class

Implements the year built prediction engine using the trained machine learning model\.

```csharp
public class YearBuiltPredictor : DiGi.GIS.IO.Interfaces.IYearBuiltPredictor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YearBuiltPredictor

Implements [DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.io.interfaces.iyearbuiltpredictor 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor')
### Constructors

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.YearBuiltPredictor()'></a>

## YearBuiltPredictor\(\) Constructor

Initializes a new instance of the [YearBuiltPredictor](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictor 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictor') class\.

```csharp
public YearBuiltPredictor();
```
### Methods

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumns(DiGi.Core.Classes.Range_int_)'></a>

## YearBuiltPredictor\.InputColumns\(Range\<int\>\) Method

Retrieves the list of columns permitted as input features for the year built prediction model across the specified range of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> InputColumns(DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumns(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for temporal features\. Defaults to 2008\.\.2025 when null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the allowed input features\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumnUniqueIds(DiGi.Core.Classes.Range_int_)'></a>

## YearBuiltPredictor\.InputColumnUniqueIds\(Range\<int\>\) Method

Retrieves the unique identifiers of the columns permitted as input features for the year built prediction model across the specified range of years\.

```csharp
public static System.Collections.Generic.List<string> InputColumnUniqueIds(DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumnUniqueIds(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for temporal features\. Defaults to 2008\.\.2025 when null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of distinct unique identifiers for the input feature columns\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.Predict(DiGi.Core.IO.Table.Classes.Table)'></a>

## YearBuiltPredictor\.Predict\(Table\) Method

Predicts the construction year for building features in the provided table\.

```csharp
public DiGi.Core.IO.Table.Classes.Table? Predict(DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.Predict(DiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing building features, including a reference column\.

Implements [Predict\(Table\)](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.io.interfaces.iyearbuiltpredictor.predict#digi-gis-io-interfaces-iyearbuiltpredictor-predict(digi-core-io-table-classes-table) 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor\.Predict\(DiGi\.Core\.IO\.Table\.Classes\.Table\)')

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
A new table carrying the reference and predicted year built columns, or null if the input table is invalid\.