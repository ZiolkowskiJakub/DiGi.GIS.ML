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

The construction year of each labelled building, by reference, as returned by `Query.YearBuiltLabels`\.

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

The construction year of each labelled building, by reference, as returned by `Query.YearBuiltLabels`\.

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

<a name='DiGi.GIS.ML.Query.DefaultOnlyColumnNames(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.DefaultOnlyColumnNames\(this Table\) Method

Names the columns of a table that carry the same value in every row\.

Written as the acceptance check on an assembled training table. A feature column that never varies teaches the regressor nothing, and on this pipeline it has a specific and expensive cause: the detection and population columns are created by runs rather than by code, so a table assembled before those runs is a full looking file in which 108 of 172 features are the default. LightGbm fits it without complaining and the resulting metrics look ordinary.

A hit is not automatically a defect - a single county genuinely shares one `County name`, and a rarely populated feature can be constant on a small sample. It is a list to explain, not a list to fail on blindly.

```csharp
public static System.Collections.Generic.List<string> DefaultOnlyColumnNames(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.DefaultOnlyColumnNames(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to inspect\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The names of the columns that never vary, in column order\. Empty when every column varies, or when the table has fewer than two rows to compare\.

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

<a name='DiGi.GIS.ML.Query.YearBuiltLabels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_)'></a>

## Query\.YearBuiltLabels\(this IEnumerable\<YearBuiltData\>\) Method

Extracts the training labels from stored year built data, by building reference\.

A stored [DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData') holds the history of every year anyone has attributed to the building, and on the counties this model trains on that includes <b>this model's own predecessor</b>: every record sampled on 2026-09-02 carried a [DiGi\.GIS\.Classes\.UserYearBuilt](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.useryearbuilt 'DiGi\.GIS\.Classes\.UserYearBuilt') together with a [DiGi\.GIS\.Classes\.PredictedYearBuilt](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.predictedyearbuilt 'DiGi\.GIS\.Classes\.PredictedYearBuilt') stamped 2025-05-29, the two disagreeing on 26 to 28 percent of records. Taking whichever year a record happens to list first would therefore train the regressor on the previous regressor's output for a quarter of its rows, and that reads as an accuracy gain rather than as a defect.

So only an entry whose [DiGi\.GIS\.Interfaces\.IYearBuilt\.YearBuiltSource](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.interfaces.iyearbuilt.yearbuiltsource 'DiGi\.GIS\.Interfaces\.IYearBuilt\.YearBuiltSource') is not [DiGi\.GIS\.Enums\.YearBuiltSource\.Prediction](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.enums.yearbuiltsource.prediction 'DiGi\.GIS\.Enums\.YearBuiltSource\.Prediction') can be a label. A record carrying nothing else is an unlabelled building and is left out rather than defaulted - a building with no known year is not a building whose year is zero.

The filter is on the source rather than on the concrete type, so a future non-prediction entry counts as ground truth without this having to be revisited.

```csharp
public static System.Collections.Generic.Dictionary<string,short> YearBuiltLabels(this System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.YearBuiltData?>? yearBuiltDatas);
```
#### Parameters

<a name='DiGi.GIS.ML.Query.YearBuiltLabels(thisSystem.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_).yearBuiltDatas'></a>

`yearBuiltDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The stored year built data to take labels from\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The construction year of each labelled building, by reference\. Empty when nothing was labelled\.