#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML\.Classes Namespace
### Classes

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult'></a>

## YearBuiltPredictionAccuracyResult Class

Reports how closely one predictor reproduced the known construction years of a set of buildings\.

Carries the three measures together on purpose. R squared alone is misleading on this label: it is measured against the variance of the holdout, and 84 percent of these rows carry the same year, so a predictor can score well while being wrong in years. The mean absolute error says how far out it is in the unit anyone cares about, and the root mean squared error says whether the misses are many small ones or a few large ones.

The name of the predictor and the name of the split are both carried, because a number is only comparable against another measured the same way - a random holdout and a holdout grouped by subdivision answer different questions of the same model.

```csharp
public class YearBuiltPredictionAccuracyResult : DiGi.Core.Classes.SerializableResult, DiGi.GIS.ML.Interfaces.IGISMLSerializableObject, DiGi.GIS.ML.Interfaces.IGISMLObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → YearBuiltPredictionAccuracyResult

Implements [IGISMLSerializableObject](DiGi.GIS.ML.Interfaces.md#DiGi.GIS.ML.Interfaces.IGISMLSerializableObject 'DiGi\.GIS\.ML\.Interfaces\.IGISMLSerializableObject'), [IGISMLObject](DiGi.GIS.ML.Interfaces.md#DiGi.GIS.ML.Interfaces.IGISMLObject 'DiGi\.GIS\.ML\.Interfaces\.IGISMLObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult)'></a>

## YearBuiltPredictionAccuracyResult\(YearBuiltPredictionAccuracyResult\) Constructor

Initializes a new instance of the [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult') class by copying values from an existing instance\.

```csharp
public YearBuiltPredictionAccuracyResult(DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult? yearBuiltPredictionAccuracyResult);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult).yearBuiltPredictionAccuracyResult'></a>

`yearBuiltPredictionAccuracyResult` [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult')

The source to copy from\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double)'></a>

## YearBuiltPredictionAccuracyResult\(string, string, int, double, double, double\) Constructor

Initializes a new instance of the [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult') class\.

Assigns only. The measures are computed by `Create.YearBuiltPredictionAccuracyResult`, which is where a caller without pre-computed values goes.

```csharp
public YearBuiltPredictionAccuracyResult(string? name, string? splitName, int count, double meanAbsoluteError, double rootMeanSquaredError, double rSquared);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The predictor these measures describe\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).splitName'></a>

`splitName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The holdout the measures were taken on\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of scored buildings\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).meanAbsoluteError'></a>

`meanAbsoluteError` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The mean absolute error, in years\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).rootMeanSquaredError'></a>

`rootMeanSquaredError` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The root mean squared error, in years\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(string,string,int,double,double,double).rSquared'></a>

`rSquared` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The coefficient of determination\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(System.Text.Json.Nodes.JsonObject)'></a>

## YearBuiltPredictionAccuracyResult\(JsonObject\) Constructor

Initializes a new instance of the [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult') class from a JSON object\.

```csharp
public YearBuiltPredictionAccuracyResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.YearBuiltPredictionAccuracyResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data\.
### Properties

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.Count'></a>

## YearBuiltPredictionAccuracyResult\.Count Property

Gets the number of scored buildings\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.MeanAbsoluteError'></a>

## YearBuiltPredictionAccuracyResult\.MeanAbsoluteError Property

Gets the mean absolute error, in years\.

```csharp
public double MeanAbsoluteError { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.Name'></a>

## YearBuiltPredictionAccuracyResult\.Name Property

Gets the predictor these measures describe\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.RootMeanSquaredError'></a>

## YearBuiltPredictionAccuracyResult\.RootMeanSquaredError Property

Gets the root mean squared error, in years\.

```csharp
public double RootMeanSquaredError { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.RSquared'></a>

## YearBuiltPredictionAccuracyResult\.RSquared Property

Gets the coefficient of determination\.

```csharp
public double RSquared { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult.SplitName'></a>

## YearBuiltPredictionAccuracyResult\.SplitName Property

Gets the holdout the measures were taken on\.

```csharp
public string? SplitName { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

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

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## YearBuiltPredictor\.InputColumns\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the list of columns permitted as input features for the year built prediction model across the specified range of years and radial radiuses\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> InputColumns(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for temporal features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the allowed input features\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumnUniqueIds(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## YearBuiltPredictor\.InputColumnUniqueIds\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the unique identifiers of the columns permitted as input features for the year built prediction model across the specified range of years and radial radiuses\.

```csharp
public static System.Collections.Generic.List<string> InputColumnUniqueIds(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumnUniqueIds(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for temporal features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.ML.Classes.YearBuiltPredictor.InputColumnUniqueIds(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

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