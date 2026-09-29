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

<b>The schema is fixed, and that is the point of this method.</b>`Modify.Update_Building2D_YearBuiltPredictions` creates the five detection columns only for years it actually saw, so a county whose orthophoto series skips a year has no columns for it and the read comes back narrower. Concatenating those tables as they arrive would line different features up under the same position. Every allow-list column is therefore materialised for every row, and a column the source did not carry is filled with the same default the inference path would have used.

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

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.PredictedYearBuilts\(this Table\) Method

Scores building feature rows into a predicted construction year\.

Every feature is read by the column it was trained against, and every one of those columns is resolved once for the whole table before a single row is read. Resolution is by stored column slug first - the identifier the database and the WebAPI address a column by - and by display name second, so a table that came from a file rather than from the database still binds.

A column the table does not carry reads as the type default, which is deliberate and has to stay that way: the training table is materialised the same way, so a feature absent at training and a feature absent at inference look identical to the model. Change one and the model sees a distribution it was never fitted on.

The generated [ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput') is the authority for this list. It is regenerated whenever the model is retrained, and the feature contract fact in DiGi.GIS.ML.xUnit fails if this and the allow-list stop agreeing.

Every column name above comes from `DiGi.GIS.IO.Constants.Column` or a `DiGi.GIS.IO.Create` factory - the same sources the DiGi.GIS.IO allow-list is assembled from - so a rename there cannot silently zero a feature in this list. The generated [ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput') is the one place that still matches by string: its `[ColumnName]` bindings are fixed only by a Model Builder regeneration of `OrtoBuildingDetectionModel.*.cs`, so a rename in DiGi.GIS.IO must always be followed by that regeneration.

```csharp
public static DiGi.Core.IO.Table.Classes.Table? PredictedYearBuilts(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.PredictedYearBuilts(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing building features, including a reference column\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')  
A new table carrying the reference and predicted year built columns, or null if the input table is null or lacks a reference column\.