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

This column is deliberately not declared in `DiGi.GIS.IO.Constants.Column`. Every column there is a stored `building_data` column, and this one is not: the label lives in the `year_built_data` table and reaches the training table only because the assembly puts it there. Declaring it beside the stored columns would invite someone to write it into `building_data`, which is the shape the leakage guards exist to prevent.

The name matches the label the incumbent model was trained against, so the regenerated `.mbconfig` keeps one `LabelColumn` across the retrain.

```csharp
public static ExtendedColumn YearBuilt;
```

#### Field Value
[DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn')