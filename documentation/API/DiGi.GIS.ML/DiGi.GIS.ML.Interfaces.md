#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\.GIS\.ML\.Interfaces Namespace
### Interfaces

<a name='DiGi.GIS.ML.Interfaces.IGISMLObject'></a>

## IGISMLObject Interface

Marks a type as belonging to the DiGi\.GIS\.ML object model\.

```csharp
public interface IGISMLObject : DiGi.Core.Interfaces.IObject
```

Derived  
↳ [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult')  
↳ [IGISMLSerializableObject](DiGi.GIS.ML.Interfaces.md#DiGi.GIS.ML.Interfaces.IGISMLSerializableObject 'DiGi\.GIS\.ML\.Interfaces\.IGISMLSerializableObject')

Implements [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.GIS.ML.Interfaces.IGISMLSerializableObject'></a>

## IGISMLSerializableObject Interface

Marks a type as a serializable member of the DiGi\.GIS\.ML object model\.

```csharp
public interface IGISMLSerializableObject : DiGi.GIS.ML.Interfaces.IGISMLObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [YearBuiltPredictionAccuracyResult](DiGi.GIS.ML.Classes.md#DiGi.GIS.ML.Classes.YearBuiltPredictionAccuracyResult 'DiGi\.GIS\.ML\.Classes\.YearBuiltPredictionAccuracyResult')

Implements [IGISMLObject](DiGi.GIS.ML.Interfaces.md#DiGi.GIS.ML.Interfaces.IGISMLObject 'DiGi\.GIS\.ML\.Interfaces\.IGISMLObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')