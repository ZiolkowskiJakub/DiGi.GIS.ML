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

<a name='DiGi.GIS.ML.Constants.Heuristic'></a>

## Heuristic Class

Provides the constants of the first\-detection heuristic that predicts the year built \(ZiolkowskiJakub/DiGi\.GIS\.ML\#15\)\.

A building is predicted to have been built in the first year the detector saw it with confidence at or above [ConfidentDetectionThreshold](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.ConfidentDetectionThreshold 'DiGi\.GIS\.ML\.Constants\.Plausibility\.ConfidentDetectionThreshold'), falling back to the first year it was seen at all. It replaced the `OrtoBuildingDetectionModel` regressor in production: scored on a county it was not trained on, every retrained regressor came out years too late, while this rule matched the labels of that county with MAE 0.15 - see `OrtoBuildingDetectionModel.provenance.md`.

```csharp
public static class Heuristic
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Heuristic
### Properties

<a name='DiGi.GIS.ML.Constants.Heuristic.Id'></a>

## Heuristic\.Id Property

Gets the identity of the heuristic, stamped on every stored prediction in place of a model file's SHA\-256\.

It names the rule and its threshold, so a change to either reads as a different predictor in the stored history (ZiolkowskiJakub/DiGi.GIS.YOLO.UI#26).

```csharp
public static string Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.ML.Constants.Heuristic.Years'></a>

## Heuristic\.Years Property

Gets the years whose detection columns the heuristic reads\.

The first of them is [FirstPredictionYear](DiGi.GIS.ML.Constants.md#DiGi.GIS.ML.Constants.Plausibility.FirstPredictionYear 'DiGi\.GIS\.ML\.Constants\.Plausibility\.FirstPredictionYear'). It is also the year range the predictor states as its contract, so a run whose options narrow the detection years - and would hide a building's first detection - is refused rather than predicted late.

```csharp
public static DiGi.Core.Classes.Range<int> Years { get; }
```

#### Property Value
[DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

<a name='DiGi.GIS.ML.Constants.Plausibility'></a>

## Plausibility Class

Provides the constants that date and bound a year built prediction by the imagery that first detected the building \(ZiolkowskiJakub/DiGi\.GIS\.ML\#14, \#15\)\.

```csharp
public static class Plausibility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Plausibility
### Fields

<a name='DiGi.GIS.ML.Constants.Plausibility.ConfidentDetectionThreshold'></a>

## Plausibility\.ConfidentDetectionThreshold Field

The confidence at or above which a year counts as a confident detection of the building\.

The first year at or above it is the year built the heuristic of `Query.PredictedYearBuilts` predicts, and the bar the acceptance criteria of ZiolkowskiJakub/DiGi.GIS.ML#14 measure a prediction against: a building confidently seen in 2008 cannot have been built in 2013.

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

The first-detection heuristic of `Query.PredictedYearBuilts` makes this share 0 by construction, so the threshold is a tripwire: a future predictor must not silently let an extrapolated score through again. It is set at 1 % to tolerate an isolated edge row rather than refusing a whole county for one.

For scale: the retired `OrtoBuildingDetectionModel` regressor ran 4.0-15.6 % on the counties it was trained on and 83.1 % on county 8956 (ZiolkowskiJakub/DiGi.GIS.ML#14); retrained without county 80328 it ran 76-89 % on it (ZiolkowskiJakub/DiGi.GIS.ML#15).

```csharp
public const double MaximumImplausibleShare = 0.01;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')