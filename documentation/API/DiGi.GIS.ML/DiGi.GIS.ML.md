#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML Namespace
### Classes

<a name='DiGi.GIS.ML.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(string,string,System.Collections.Generic.IEnumerable_System.Nullable_double__,System.Collections.Generic.IEnumerable_System.Nullable_double__)'></a>

## Create\.YearBuiltPredictionAccuracyResult\(string, string, IEnumerable\<Nullable\<double\>\>, IEnumerable\<Nullable\<double\>\>\) Method

Measures how closely a set of predicted construction years reproduced the known ones\.

The two sequences are read in step and a pair is used only when both sides have a value, so a predictor that declines to answer for some buildings is measured on what it did answer rather than being charged a default. The count on the result says how many pairs that was, which is what makes two results comparable.

R squared is computed against the variance of the supplied known years rather than of the whole dataset, so it describes this holdout and no other. It comes back as [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when every known year in the holdout is the same value, because there is then no variance to explain and any number would be an artefact.

```csharp
public static DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult? YearBuiltPredictionAccuracyResult(string? name, string? splitName, System.Collections.Generic.IEnumerable<System.Nullable<double>>? years, System.Collections.Generic.IEnumerable<System.Nullable<double>>? years_Predicted);
```
#### Parameters

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(string,string,System.Collections.Generic.IEnumerable_System.Nullable_double__,System.Collections.Generic.IEnumerable_System.Nullable_double__).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The predictor these measures describe\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(string,string,System.Collections.Generic.IEnumerable_System.Nullable_double__,System.Collections.Generic.IEnumerable_System.Nullable_double__).splitName'></a>

`splitName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The holdout the measures are being taken on\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(string,string,System.Collections.Generic.IEnumerable_System.Nullable_double__,System.Collections.Generic.IEnumerable_System.Nullable_double__).years'></a>

`years` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The known construction years\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionAccuracyResult(string,string,System.Collections.Generic.IEnumerable_System.Nullable_double__,System.Collections.Generic.IEnumerable_System.Nullable_double__).years_Predicted'></a>

`years_Predicted` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The predicted construction years, in the same order\.

#### Returns
[YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult')  
The measures, or null when there is no pair to measure\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionInputTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.YearBuiltPredictionInputTable\(this IEnumerable\<Table\>, Range\<int\>, IEnumerable\<double\>\) Method

Builds the Year Built prediction input table from stored building feature tables: the projection the regressor scores, for every building, labelled or not\.

The result is the reference, then every column of `DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns` in its own order. [YearBuiltPredictionTrainingTable\(this IEnumerable&lt;Table&gt;, IDictionary&lt;string,short&gt;, Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.ML\.Create\.YearBuiltPredictionTrainingTable\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Core\.IO\.Table\.Classes\.Table\>, System\.Collections\.Generic\.IDictionary\<string,short\>, DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') is this table filtered to the labelled buildings with the label appended, so a county scored from this table is shown exactly the features a training row of the same building would have carried.

<b>The schema is fixed, and that is the point of this method.</b>`Modify.Update_Building2D_YearBuiltPredictions` creates the five detection columns only for years it actually saw, so a county whose orthophoto series skips a year has no columns for it and the read comes back narrower. Concatenating those tables as they arrive would line different features up under the same position. Every allow-list column is therefore materialised for every row, and a column the source did not carry is filled with the same default the inference path would have used.

That default matters more than it looks. `Query.PredictedYearBuilts` reads an absent feature as `0F`, so training on an absent feature written as anything else would show the model one distribution and the deployed pipeline another.

A reference read twice - overlapping pages, or a county asked for more than once - becomes one row, the first one read.

```csharp
public static DiGi.Core.IO.Table.Classes.Table? YearBuiltPredictionInputTable(this System.Collections.Generic.IEnumerable<DiGi.Core.IO.Table.Classes.Table?>? tables, DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionInputTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).tables'></a>

`tables` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The stored feature tables to draw rows from, typically one page or one county each\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionInputTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for the detection and population features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionInputTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The radiuses for the radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
The input table, or null when there is nothing to build one from\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.YearBuiltPredictionTrainingTable\(this Table, IDictionary\<string,short\>, Range\<int\>, IEnumerable\<double\>\) Method

Builds the Year Built prediction training table from one stored building feature table and the labels of those buildings\.

```csharp
public static DiGi.Core.IO.Table.Classes.Table? YearBuiltPredictionTrainingTable(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IDictionary<string,short>? years_ByReference, DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The stored feature table to draw rows from\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years_ByReference'></a>

`years_ByReference` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The construction year of each labelled building, by reference, as returned by `DiGi.GIS.IO.Query.YearBuiltLabels`\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for the detection and population features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The radiuses for the radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
The training table, or null when there is nothing to build one from\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.YearBuiltPredictionTrainingTable\(this IEnumerable\<Table\>, IDictionary\<string,short\>, Range\<int\>, IEnumerable\<double\>\) Method

Builds the Year Built prediction training table from stored building feature tables and the labels of those buildings\.

The result is the projection the regressor is trained on: the reference, then every column of `DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns` in its own order, then the label. The reference is an identifier rather than a feature and the incumbent model ignores it; it is carried so a row can be traced back to its building.

It is [YearBuiltPredictionInputTable\(this IEnumerable&lt;Table&gt;, Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Create.YearBuiltPredictionInputTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.ML\.Create\.YearBuiltPredictionInputTable\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Core\.IO\.Table\.Classes\.Table\>, DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') filtered to the labelled buildings with the label appended. <b>The schema is fixed, and that is the point of both methods.</b>`Modify.Update_Building2D_YearBuiltPredictions` creates the five detection columns only for years it actually saw, so a county whose orthophoto series skips a year has no columns for it and the read comes back narrower. Concatenating those tables as they arrive would line different features up under the same position. Every allow-list column is therefore materialised for every row, and a column the source did not carry is filled with the same default the inference path would have used.

That default matters more than it looks. `Query.PredictedYearBuilts` reads an absent feature as `0F`, so training on an absent feature written as anything else would show the model one distribution and the deployed pipeline another.

Only a labelled building becomes a row. A building with no label is skipped rather than defaulted, because a building whose year nobody knows is not a building built in year zero.

```csharp
public static DiGi.Core.IO.Table.Classes.Table? YearBuiltPredictionTrainingTable(this System.Collections.Generic.IEnumerable<DiGi.Core.IO.Table.Classes.Table?>? tables, System.Collections.Generic.IDictionary<string,short>? years_ByReference, DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).tables'></a>

`tables` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The stored feature tables to draw rows from, typically one page or one county each\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years_ByReference'></a>

`years_ByReference` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The construction year of each labelled building, by reference, as returned by `DiGi.GIS.IO.Query.YearBuiltLabels`\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for the detection and population features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.ML.Create.YearBuiltPredictionTrainingTable(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_,System.Collections.Generic.IDictionary_string,short_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The radiuses for the radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
The training table, or null when there is nothing to build one from\.

<a name='DiGi.GIS.ML.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.ML.Query.CleanHoldouts(thisSystem.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_bool_,System.Collections.Generic.Dictionary_string,bool_)'></a>

## Query\.CleanHoldouts\(this IEnumerable\<string\>, IEnumerable\<bool\>, Dictionary\<string,bool\>\) Method

Narrows a holdout to the buildings the detector's previous training cannot have seen\.

A row is clean when it is in the holdout and its reference is in the manifest with `Legacy = false`. A reference absent from the manifest is unknown, not clean, and is left out.

```csharp
public static System.Collections.Generic.List<bool> CleanHoldouts(this System.Collections.Generic.IEnumerable<string?>? references, System.Collections.Generic.IEnumerable<bool>? holdouts, System.Collections.Generic.Dictionary<string,bool>? legacyFlags);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.CleanHoldouts(thisSystem.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_bool_,System.Collections.Generic.Dictionary_string,bool_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The building reference of each row, in row order\.

<a name='DiGi.GIS.ML.Query.CleanHoldouts(thisSystem.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_bool_,System.Collections.Generic.Dictionary_string,bool_).holdouts'></a>

`holdouts` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

True for each row in the holdout, in row order, as returned by `DiGi.GIS.IO.Query.Holdouts`\.

<a name='DiGi.GIS.ML.Query.CleanHoldouts(thisSystem.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_bool_,System.Collections.Generic.Dictionary_string,bool_).legacyFlags'></a>

`legacyFlags` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

The `Legacy` flag by reference, as returned by [LegacyFlags\(this Table\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Query.LegacyFlags(thisDiGi.Core.IO.Table.Classes.Table) 'DiGi\.GIS\.ML\.Query\.LegacyFlags\(this DiGi\.Core\.IO\.Table\.Classes\.Table\)')\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
True for each clean holdout row, in row order\. Empty when any argument is null\.

<a name='DiGi.GIS.ML.Query.ColumnIndex(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.IO.Table.Classes.Column)'></a>

## Query\.ColumnIndex\(this Table, Column\) Method

Finds the index of a column in a table by its stored column slug first and by its display name second\.

The slug is the identifier the database and the WebAPI address a column by, so a table read through the API binds whatever its display names are; the display name is the fallback for a table that came from a file. This is the resolution the deployed scoring path has always used.

```csharp
public static int ColumnIndex(this DiGi.Core.IO.Table.Classes.Table? table, DiGi.Core.IO.Table.Classes.Column? column);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.ColumnIndex(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.IO.Table.Classes.Column).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to search, or null\.

<a name='DiGi.GIS.ML.Query.ColumnIndex(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.IO.Table.Classes.Column).column'></a>

`column` [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

The column to find, or null\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The index of the column, or \-1 when the table or the column is null or the table does not carry it\.

<a name='DiGi.GIS.ML.Query.FirstConfidentDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,float)'></a>

## Query\.FirstConfidentDetectionYears\(this Table, float\) Method

Finds, for each row, the first year the detector saw the building with confidence at or above a threshold\.

With the default threshold, [ConfidentDetectionThreshold](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.ConfidentDetectionThreshold 'DiGi\.GIS\.ML\.Constants\.Plausibility\.ConfidentDetectionThreshold'), this is the year built the heuristic of [PredictedYearBuilts\(this Table\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table) 'DiGi\.GIS\.ML\.Query\.PredictedYearBuilts\(this DiGi\.Core\.IO\.Table\.Classes\.Table\)') predicts, and the bound a prediction is judged against: a building confidently seen in a year cannot have been built after it. A threshold of 0 finds the first year the building was seen at all - any confidence above zero - which is the fallback of that heuristic.

The years scanned are [Years](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Heuristic.Years 'DiGi\.GIS\.ML\.Constants\.Heuristic\.Years'), and each confidence column is resolved by [ColumnIndex\(this Table, Column\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Query.ColumnIndex(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.IO.Table.Classes.Column) 'DiGi\.GIS\.ML\.Query\.ColumnIndex\(this DiGi\.Core\.IO\.Table\.Classes\.Table, DiGi\.Core\.IO\.Table\.Classes\.Column\)'), so a table read through the WebAPI binds the same way the scoring path does.

Unlike `DiGi.GIS.IO.Query.FirstDetectionYears`, which falls back to a default year, a row with no detection at the threshold is `null` here: it has nothing to be dated or judged by, and a default would count it as evidence.

```csharp
public static System.Collections.Generic.List<System.Nullable<int>> FirstConfidentDetectionYears(this DiGi.Core.IO.Table.Classes.Table? table, float threshold=0.5f);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.FirstConfidentDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,float).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table carrying the per\-year `Prediction Confidence` columns, or null\.

<a name='DiGi.GIS.ML.Query.FirstConfidentDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,float).threshold'></a>

`threshold` [System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

The confidence a detection must reach to count\. 0 counts any confidence above zero\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One entry per row, in row order: the first year at the threshold, or null when the row has none\. Empty when the table is null or holds no rows\.

<a name='DiGi.GIS.ML.Query.IsPlausibleShare(thisdouble)'></a>

## Query\.IsPlausibleShare\(this double\) Method

Tells whether a share of predictions later than their first confident detection year is within the plausibility maximum\.

This is the refusal condition of the plausibility guard in [PredictedYearBuilts\(this Table\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table) 'DiGi\.GIS\.ML\.Query\.PredictedYearBuilts\(this DiGi\.Core\.IO\.Table\.Classes\.Table\)'). The share is allowed to sit exactly at [MaximumImplausibleShare](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.MaximumImplausibleShare 'DiGi\.GIS\.ML\.Constants\.Plausibility\.MaximumImplausibleShare'); only a share over it makes the run refuse. The first-detection heuristic makes the share 0 by construction, so the predicate exists to pin the boundary - a future change that lets an extrapolated score through again must cross this line visibly rather than drift with it.

```csharp
public static bool IsPlausibleShare(this double share);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.IsPlausibleShare(thisdouble).share'></a>

`share` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The share of scored rows whose predicted year is later than their first confident detection year\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the share is within the maximum; false when the run must refuse to return predictions\.

<a name='DiGi.GIS.ML.Query.LegacyFlags(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.LegacyFlags\(this Table\) Method

Reads the `Legacy` flag of each building from the `dataset_references.tsv` manifest written by the YOLO dataset builder \(DiGi\.GIS\.YOLO\.UI\)\.

The columns are read by name: `Reference` and `Legacy`. The manifest is a file contract only - this library has no reference to DiGi.GIS.YOLO.UI. This method reads the flag, it does not re-derive it: the dataset builder decides which buildings `train8` saw.

A manifest that lacks either column, or holds a `Legacy` value that is not a boolean, is refused with null rather than read as all-clean: a clean holdout that silently includes legacy buildings would report an inflated score as an unseen one.

```csharp
public static System.Collections.Generic.Dictionary<string,bool>? LegacyFlags(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.LegacyFlags(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The manifest table, or null\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The `Legacy` flag by reference, or null when the manifest is null, lacks a required column or holds an unreadable flag\.

<a name='DiGi.GIS.ML.Query.PredictedYear(thisdouble)'></a>

## Query\.PredictedYear\(this double\) Method

Rounds a raw regressor score to the year [PredictedYearBuilts\(this Table\)](DiGi.GIS.ML.md#DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table) 'DiGi\.GIS\.ML\.Query\.PredictedYearBuilts\(this DiGi\.Core\.IO\.Table\.Classes\.Table\)') writes for it\.

An exact half rounds down - a score of 2008.5 is 2008 - and the result is clamped to the [System\.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16 'System\.UInt16') range the predicted year column stores. Anything that judges a raw score against a detection year rounds it here first, so a measurement and the deployed path cannot disagree by a rounding rule.

```csharp
public static int PredictedYear(this double score);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.PredictedYear(thisdouble).score'></a>

`score` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The raw score of the regressor\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The predicted year, within \[0, [System\.UInt16\.MaxValue](https://learn.microsoft.com/en-us/dotnet/api/system.uint16.maxvalue 'System\.UInt16\.MaxValue')\]\.

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.PredictedYearBuilts\(this Table\) Method

Predicts the construction year of each building from the imagery that detected it\.

A building is predicted to have been built in the first year the detector saw it with confidence at or above [ConfidentDetectionThreshold](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.ConfidentDetectionThreshold 'DiGi\.GIS\.ML\.Constants\.Plausibility\.ConfidentDetectionThreshold'), falling back to the first year it was seen at all. A building the detector never saw has nothing to be dated by and is left out of the result rather than filled with a default, as `IYearBuiltPredictor.Predict` allows.

This heuristic replaced the `OrtoBuildingDetectionModel` regressor (ZiolkowskiJakub/DiGi.GIS.ML#15). The regressor memorised the counties it was trained on - their location, and the pattern of orthophoto years each one has - and scored any other county years too late: on held-out county 80328 every retrain put 76-89 % of buildings after their first confident detection, while this rule matched its labels with MAE 0.15. The label is itself the first year a building appears in the orthophoto record, so the first detection is its direct estimate. The model and its tooling stay in the repository for a feature redesign that has to beat this rule on a held-out county first.

The run reports how many buildings were dated from a confident detection, from a weaker one only, and how many were left out. It keeps the guard of ZiolkowskiJakub/DiGi.GIS.ML#14: the share of predictions later than their first confident detection year is 0 by construction here, and the table is refused if a future change lets it exceed [MaximumImplausibleShare](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.MaximumImplausibleShare 'DiGi\.GIS\.ML\.Constants\.Plausibility\.MaximumImplausibleShare').

```csharp
public static DiGi.Core.IO.Table.Classes.Table? PredictedYearBuilts(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing building features, including a reference column and the per\-year `Prediction Confidence` columns\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
A new table carrying the reference and predicted year built columns, one row per detected building, or null if the input table is null, lacks a reference column, or fails the plausibility guard\.