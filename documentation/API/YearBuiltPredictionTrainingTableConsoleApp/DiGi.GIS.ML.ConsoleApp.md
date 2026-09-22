#### [YearBuiltPredictionTrainingTableConsoleApp](YearBuiltPredictionTrainingTableConsoleApp.Overview.md 'YearBuiltPredictionTrainingTableConsoleApp\.Overview')

## DiGi\.GIS\.ML\.ConsoleApp Namespace
### Classes

<a name='DiGi.GIS.ML.ConsoleApp.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken)'></a>

## Query\.BuildingDataTableAsync\(this GISWebAPIManager, int, IEnumerable\<string\>, string, int, PostOptions, CancellationToken\) Method

Reads the stored building data of the named county as a table, projected to the named columns, one keyset page at a time\.

The page is keyed by reference: the server answers the first `pageSize` rows after `cursor` - or from the start when it is null - and the caller advances `cursor` to the last reference it read until a short page answers. A page shorter than `pageSize` is the end of the county.

The projection is an allow-list, and the same allow-list the inference pipeline projects through - `DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns` - so asking for every column would hand the trainer the pipeline's own output column back as a feature. The server always adds `Reference` and `County Id` on top of it.

```csharp
public static System.Threading.Tasks.Task<DiGi.Core.IO.Table.Classes.Table?> BuildingDataTableAsync(this DiGi.GIS.WebAPI.Classes.GISWebAPIManager? gisWebAPIManager, int countyId, System.Collections.Generic.IEnumerable<string>? columnUniqueIds, string? cursor, int pageSize, DiGi.WebAPI.Classes.PostOptions? postOptions=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).gisWebAPIManager'></a>

`gisWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the WebAPI\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The identifier of the county partition to page\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).columnUniqueIds'></a>

`columnUniqueIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The unique identifiers of the columns to project\. Null or empty asks for every column, which this never wants\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).cursor'></a>

`cursor` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The last reference read on the previous page, or null for the first page\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).pageSize'></a>

`pageSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The page size, within the endpoint's \[1, 10000\] range\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the request\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,string,int,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') to observe while waiting for the task to complete\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task returning the page as a projected table, or null when it could not be read\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken)'></a>

## Query\.BuildingDataTableAsync\(this GISWebAPIManager, int, IEnumerable\<string\>, IEnumerable\<string\>, PostOptions, CancellationToken\) Method

Reads the stored building data of the named references as a table, projected to the named columns\.

The projection is an allow-list rather than a filter, and it is the same allow-list the inference pipeline projects through - `DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns`. Asking for every column instead would hand the trainer the pipeline's own output column back as a feature, which reads as a large accuracy gain rather than as a defect.

Deliberately mirrors `DiGi.GIS.YOLO.UI.Query.BuildingDataTableAsync` rather than referencing it: that assembly targets `net10.0-windows7.0` and carries the image export, and a training table assembler has no business loading `System.Drawing`. The contract the two must agree on is the column list, and that is shared rather than copied.

```csharp
public static System.Threading.Tasks.Task<DiGi.Core.IO.Table.Classes.Table?> BuildingDataTableAsync(this DiGi.GIS.WebAPI.Classes.GISWebAPIManager? gisWebAPIManager, int countyId, System.Collections.Generic.IEnumerable<string>? references, System.Collections.Generic.IEnumerable<string>? columnUniqueIds, DiGi.WebAPI.Classes.PostOptions? postOptions=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).gisWebAPIManager'></a>

`gisWebAPIManager` [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.classes.giswebapimanager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') instance used to communicate with the WebAPI\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The identifier of the county row the references belong to\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The building references to read, at most the endpoint's cap\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).columnUniqueIds'></a>

`columnUniqueIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The unique identifiers of the columns to project\. Null or empty asks for every column, which this never wants\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).postOptions'></a>

`postOptions` [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions')

Optional configuration options for the request\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.BuildingDataTableAsync(thisDiGi.GIS.WebAPI.Classes.GISWebAPIManager,int,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,DiGi.WebAPI.Classes.PostOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') to observe while waiting for the task to complete\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task returning the projected table, or null when it could not be read\.

<a name='DiGi.GIS.ML.ConsoleApp.Query.Key(string)'></a>

## Query\.Key\(string\) Method

Reads the WebAPI authorization key from the deployed client configuration file\.

Only the output root is probed. `CopyUserFiles` runs after `CopyFiles` and both flatten into it, so the git-ignored `user files` copy overwrites the committed default of the same name; a `bin\user files` folder is never produced, and probing for one would read as a working fallback while finding nothing.

```csharp
public static string? Key(string? path=null);
```
#### Parameters

<a name='DiGi.GIS.ML.ConsoleApp.Query.Key(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Optional explicit path to the configuration file\. Resolved against the output root when omitted\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The key if one is configured; otherwise null\.