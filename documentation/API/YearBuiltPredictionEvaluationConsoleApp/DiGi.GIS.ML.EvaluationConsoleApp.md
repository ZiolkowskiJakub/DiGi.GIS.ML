#### [YearBuiltPredictionEvaluationConsoleApp](YearBuiltPredictionEvaluationConsoleApp.Overview.md 'YearBuiltPredictionEvaluationConsoleApp\.Overview')

## DiGi\.GIS\.ML\.EvaluationConsoleApp Namespace
### Classes

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string)'></a>

## Query\.Scores\(string, string, IEnumerable\<string\>, IEnumerable\<string\>, string\) Method

Scores every row of a delimited training table with a saved ML\.NET model\.

The loader is built from the model's own input schema rather than from a generated `ModelInput` class, so any model trained on this table can be scored without compiling its generated code alongside. A column the model wants and the file does not have is loaded as a default, which is what the inference path does too.

```csharp
public static System.Collections.Generic.List<System.Nullable<double>>? Scores(string? path_Model, string? path_Table, System.Collections.Generic.IEnumerable<string>? names_String=null, System.Collections.Generic.IEnumerable<string>? names_Boolean=null, string scoreColumnName="Score");
```
#### Parameters

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string).path_Model'></a>

`path_Model` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The saved model\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string).path_Table'></a>

`path_Table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The tab separated training table, with a header row\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string).names_String'></a>

`names_String` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Columns the model reads as text\. The saved input schema cannot be trusted for this \- it reports a categorical column as Single while the transform chain that follows maps it as String, and the mismatch surfaces only when the chain runs\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string).names_Boolean'></a>

`names_Boolean` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Columns the model reads as a boolean\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Scores(string,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,string).scoreColumnName'></a>

`scoreColumnName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The output column carrying the prediction\. ML\.NET regression names it Score\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The predicted value of each row, in file order, or null when the model or the table could not be read\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Split(System.Collections.Generic.IEnumerable_string_,int)'></a>

## Query\.Split\(IEnumerable\<string\>, int\) Method

Decides which rows form the holdout, by hashing a key rather than by shuffling\.

A seeded shuffle is only reproducible inside one runtime: the same seed gives different orders in .NET and in Python, and the framework is free to change its generator between versions. Hashing the key makes membership a property of the row, so the same holdout comes back on any machine, in any language, in any order, and two runs months apart stay comparable.

The hash is FNV-1a over the UTF-8 bytes, written out here rather than taken from `string.GetHashCode`, which is randomised per process and would put the same building in a different half on every run.

Pass the building reference to hold out roughly one row in five. Pass the subdivision identifier to hold out whole subdivisions instead, so no subdivision spans training and holdout - that is the control for a model memorising neighbourhoods rather than reading the imagery.

```csharp
public static System.Collections.Generic.List<bool> Split(System.Collections.Generic.IEnumerable<string?>? keys, int denominator=5);
```
#### Parameters

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Split(System.Collections.Generic.IEnumerable_string_,int).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The key of each row, in row order\.

<a name='DiGi.GIS.ML.EvaluationConsoleApp.Query.Split(System.Collections.Generic.IEnumerable_string_,int).denominator'></a>

`denominator` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

One row in this many joins the holdout\. 5 gives a 20 percent holdout\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
True for each row that belongs to the holdout, in row order\.