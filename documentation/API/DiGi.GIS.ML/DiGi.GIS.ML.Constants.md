#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML\.Constants Namespace
### Classes

<a name='DiGi.GIS.ML.Constants.Column'></a>

## Column Class

Provides the columns that exist only in the Year Built prediction training table\.

```csharp
public static class Column
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Column
### Fields

<a name='DiGi.GIS.ML.Constants.Column.YearBuilt'></a>

## Column\.YearBuilt Field

The construction year the model is trained against\.

The label's source is the stored `User year built` column of `building_data` - `DiGi.GIS.IO.Constants.Column.UserYearBuilt` - not the `year_built_data` table the label used to come from. This training-table column stays deliberately out of that catalogue: it is a training-table column, not a `building_data` column, and keeping it out of `DiGi.GIS.IO.Constants.Column` keeps it out of `gis/buildingdata/columns`, the typology pickers and every feature projection.

The name and the `short` type match the label the incumbent model was trained against, so the regenerated `.mbconfig` keeps one `LabelColumn` across the retrain.

```csharp
public static ExtendedColumn YearBuilt;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')

<a name='DiGi.GIS.ML.Constants.Plausibility'></a>

## Plausibility Class

Provides the constants that bound a year built prediction by the imagery that first detected the building \(ZiolkowskiJakub/DiGi\.GIS\.ML\#14\)\.

```csharp
public static class Plausibility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Plausibility
### Fields

<a name='DiGi.GIS.ML.Constants.Plausibility.ConfidentDetectionThreshold'></a>

## Plausibility\.ConfidentDetectionThreshold Field

The confidence at or above which a year counts as a confident detection of the building\.

This is the same bar the acceptance criteria of ZiolkowskiJakub/DiGi.GIS.ML#14 measure a prediction against: a building confidently seen in 2008 cannot have been built in 2013.

```csharp
public const float ConfidentDetectionThreshold = 0.5;
```

#### Field Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi.GIS.ML.Constants.Plausibility.FirstPredictionYear'></a>

## Plausibility\.FirstPredictionYear Field

The first year the orthophoto sequence emits per\-year detection columns for\.

A detection year is [FirstPredictionYear](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.FirstPredictionYear 'DiGi\.GIS\.ML\.Constants\.Plausibility\.FirstPredictionYear') plus the index of the first confidence column reporting the building, so this constant has to move with the sequence.

```csharp
public const int FirstPredictionYear = 2008;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.ML.Constants.Plausibility.MaximumImplausibleShare'></a>

## Plausibility\.MaximumImplausibleShare Field

The maximum share of predictions that may be later than their first confident detection year before a table is returned\.

While the plausibility cap in `Query.PredictedYearBuilts` is in place this share is 0 by construction, so the threshold is a tripwire: a future change to the cap must not silently let an extrapolated score through again. It is set at 1 % to tolerate an isolated edge row rather than refusing a whole county for one.

Calibrated against the raw (uncapped) shares measured on 2026 imagery: healthy and training counties run 4.0-15.6 %, while county 8956 - the county of ZiolkowskiJakub/DiGi.GIS.ML#14, whose model inputs extrapolate - ran 83.1 %.

```csharp
public const double MaximumImplausibleShare = 0.01;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')