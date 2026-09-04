#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\_GIS\_ML Namespace
### Classes

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel'></a>

## OrtoBuildingDetectionModel Class

Readiness surface for the generated model, kept in a partial the Model Builder does not own so a retrain does not revert it\.

A hand-fix inside OrtoBuildingDetectionModel.consumption.cs would be regenerated away on the next retrain; a sibling partial is where the correction survives. Its one dependency - the hand-maintained private MLNetModelPath - is recorded in OrtoBuildingDetectionModel.provenance.md so a retrain re-establishes it.

```csharp
public class OrtoBuildingDetectionModel
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OrtoBuildingDetectionModel
### Fields

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PredictEngine'></a>

## OrtoBuildingDetectionModel\.PredictEngine Field

The prediction engine used to make single predictions on [ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput')\.

```csharp
public static readonly Lazy<PredictionEngine<ModelInput,ModelOutput>> PredictEngine;
```

#### Field Value
[System\.Lazy&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.lazy-1 'System\.Lazy\`1')[Microsoft\.ML\.PredictionEngine&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.predictionengine-2 'Microsoft\.ML\.PredictionEngine\`2')[ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput')[,](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.predictionengine-2 'Microsoft\.ML\.PredictionEngine\`2')[ModelOutput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.predictionengine-2 'Microsoft\.ML\.PredictionEngine\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.lazy-1 'System\.Lazy\`1')
### Properties

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.IsModelAvailable'></a>

## OrtoBuildingDetectionModel\.IsModelAvailable Property

Gets whether the trained model file is present at the resolved path\.

```csharp
public static bool IsModelAvailable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ResolvedModelPath'></a>

## OrtoBuildingDetectionModel\.ResolvedModelPath Property

Gets the resolved model path, for the diagnostic when it is not present\.

```csharp
public static string ResolvedModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.BuildPipeline(Microsoft.ML.MLContext)'></a>

## OrtoBuildingDetectionModel\.BuildPipeline\(MLContext\) Method

build the pipeline that is used from model builder\. Use this function to retrain model\.

```csharp
public static Microsoft.ML.IEstimator<Microsoft.ML.ITransformer> BuildPipeline(Microsoft.ML.MLContext mlContext);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.BuildPipeline(Microsoft.ML.MLContext).mlContext'></a>

`mlContext` [Microsoft\.ML\.MLContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.mlcontext 'Microsoft\.ML\.MLContext')

#### Returns
[Microsoft\.ML\.IEstimator&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.iestimator-1 'Microsoft\.ML\.IEstimator\`1')[Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.iestimator-1 'Microsoft\.ML\.IEstimator\`1')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool)'></a>

## OrtoBuildingDetectionModel\.LoadIDataViewFromFile\(MLContext, string, char, bool, bool\) Method

Load an IDataView from a file path\.

```csharp
public static Microsoft.ML.IDataView LoadIDataViewFromFile(Microsoft.ML.MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader, bool allowQuoting);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool).mlContext'></a>

`mlContext` [Microsoft\.ML\.MLContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.mlcontext 'Microsoft\.ML\.MLContext')

The common context for all ML\.NET operations\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool).inputDataFilePath'></a>

`inputDataFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Path to the data file for training\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool).separatorChar'></a>

`separatorChar` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

Separator character for delimited training file\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool).hasHeader'></a>

`hasHeader` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Boolean if training file has a header\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.LoadIDataViewFromFile(Microsoft.ML.MLContext,string,char,bool,bool).allowQuoting'></a>

`allowQuoting` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Boolean if quoting is allowed in the training file\.

#### Returns
[Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')  
IDataView with loaded training data\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Predict(DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput)'></a>

## OrtoBuildingDetectionModel\.Predict\(ModelInput\) Method

Use this method to predict on [ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput')\.

```csharp
public static DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput Predict(DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput input);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Predict(DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput).input'></a>

`input` [ModelInput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelInput')

model input\.

#### Returns
[ModelOutput](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelOutput')  
\<seealso cref="T:DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.ModelOutput" /\>

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainModel(Microsoft.ML.MLContext,Microsoft.ML.IDataView)'></a>

## OrtoBuildingDetectionModel\.RetrainModel\(MLContext, IDataView\) Method

Retrain model using the pipeline generated as part of the training process\.

```csharp
public static Microsoft.ML.ITransformer RetrainModel(Microsoft.ML.MLContext mlContext, Microsoft.ML.IDataView trainData);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainModel(Microsoft.ML.MLContext,Microsoft.ML.IDataView).mlContext'></a>

`mlContext` [Microsoft\.ML\.MLContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.mlcontext 'Microsoft\.ML\.MLContext')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainModel(Microsoft.ML.MLContext,Microsoft.ML.IDataView).trainData'></a>

`trainData` [Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')

#### Returns
[Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.SaveModel(Microsoft.ML.MLContext,Microsoft.ML.ITransformer,Microsoft.ML.IDataView,string)'></a>

## OrtoBuildingDetectionModel\.SaveModel\(MLContext, ITransformer, IDataView, string\) Method

Save a model at the specified path\.

```csharp
public static void SaveModel(Microsoft.ML.MLContext mlContext, Microsoft.ML.ITransformer model, Microsoft.ML.IDataView data, string modelSavePath);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.SaveModel(Microsoft.ML.MLContext,Microsoft.ML.ITransformer,Microsoft.ML.IDataView,string).mlContext'></a>

`mlContext` [Microsoft\.ML\.MLContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.mlcontext 'Microsoft\.ML\.MLContext')

The common context for all ML\.NET operations\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.SaveModel(Microsoft.ML.MLContext,Microsoft.ML.ITransformer,Microsoft.ML.IDataView,string).model'></a>

`model` [Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')

Model to save\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.SaveModel(Microsoft.ML.MLContext,Microsoft.ML.ITransformer,Microsoft.ML.IDataView,string).data'></a>

`data` [Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')

IDataView used to train the model\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.SaveModel(Microsoft.ML.MLContext,Microsoft.ML.ITransformer,Microsoft.ML.IDataView,string).modelSavePath'></a>

`modelSavePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

File path for saving the model\. Should be similar to "C:\\YourPath\\ModelName\.mlnet\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool)'></a>

## OrtoBuildingDetectionModel\.Train\(string, string, char, bool, bool\) Method

Train a new model with the provided dataset\.

```csharp
public static void Train(string outputModelPath, string inputDataFilePath="training_all.tsv", char separatorChar='\t', bool hasHeader=true, bool allowQuoting=false);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool).outputModelPath'></a>

`outputModelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

File path for saving the model\. Should be similar to "C:\\YourPath\\ModelName\.mlnet"

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool).inputDataFilePath'></a>

`inputDataFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Path to the data file for training\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool).separatorChar'></a>

`separatorChar` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

Separator character for delimited training file\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool).hasHeader'></a>

`hasHeader` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Boolean if training file has a header\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.Train(string,string,char,bool,bool).allowQuoting'></a>

`allowQuoting` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Boolean if quoting is allowed in the training file\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput'></a>

## OrtoBuildingDetectionModel\.ModelInput Class

model input class for YearBuiltPrediction\.

```csharp
public class OrtoBuildingDetectionModel.ModelInput
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelInput

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput'></a>

## OrtoBuildingDetectionModel\.ModelOutput Class

model output class for YearBuiltPrediction\.

```csharp
public class OrtoBuildingDetectionModel.ModelOutput
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelOutput