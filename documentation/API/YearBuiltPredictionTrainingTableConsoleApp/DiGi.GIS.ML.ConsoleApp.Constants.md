#### [YearBuiltPredictionTrainingTableConsoleApp](YearBuiltPredictionTrainingTableConsoleApp.Overview.md 'YearBuiltPredictionTrainingTableConsoleApp\.Overview')

## DiGi\.GIS\.ML\.ConsoleApp\.Constants Namespace
### Classes

<a name='DiGi.GIS.ML.ConsoleApp.Constants.Count'></a>

## Count Class

Provides the request size limits the deployed WebAPI enforces\.

```csharp
public static class Count
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Count
### Fields

<a name='DiGi.GIS.ML.ConsoleApp.Constants.Count.Reference_Maximum'></a>

## Count\.Reference\_Maximum Field

The greatest number of references either bulk endpoint accepts in one request\.

Mirrors `referenceCount_Maximum` on `BuildingDataController` and `YearBuiltDataController`. A larger page is refused outright rather than merely being slower, and it fails the whole page, so the caller pages to this rather than discovering it from a 400.

```csharp
public const int Reference_Maximum = 10000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.ML.ConsoleApp.Constants.Count.Row_Maximum'></a>

## Count\.Row\_Maximum Field

The page size of the keyset\-paged label read\.

The label read projects the single `User year built` column beside the `Reference` and `County Id` the server always adds, so a page is light and well under the endpoint's `PageSize` cap of 10 000. A 3-column page at 5 000 rows is small enough to keep the request fast without paging a county in a hundred calls.

```csharp
public const int Row_Maximum = 5000;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.ML.ConsoleApp.Constants.FileName'></a>

## FileName Class

Provides the configuration file names this runner reads from its output directory\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.GIS.ML.ConsoleApp.Constants.FileName.GISWebAPIClientConfigurationFile'></a>

## FileName\.GISWebAPIClientConfigurationFile Field

The WebAPI client configuration carrying the authorization key\. Git\-ignored, deployed by `CopyUserFiles`\.

```csharp
public const string GISWebAPIClientConfigurationFile = "GIS_WebAPI_Client.conf";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')