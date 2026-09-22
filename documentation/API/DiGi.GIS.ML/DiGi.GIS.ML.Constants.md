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