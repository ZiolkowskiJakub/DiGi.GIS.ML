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