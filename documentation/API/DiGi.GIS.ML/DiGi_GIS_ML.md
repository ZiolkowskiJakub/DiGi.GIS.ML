#### [DiGi\.GIS\.ML](DiGi.GIS.ML.Overview.md 'DiGi\.GIS\.ML\.Overview')

## DiGi\_GIS\_ML Namespace
### Classes

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel'></a>

## OrtoBuildingDetectionModel Class

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

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.CalculatePFI(Microsoft.ML.MLContext,Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string)'></a>

## OrtoBuildingDetectionModel\.CalculatePFI\(MLContext, IDataView, ITransformer, string\) Method

Permutation feature importance \(PFI\) is a technique to determine the importance 
of features in a trained machine learning model\. PFI works by taking a labeled dataset, 
choosing a feature, and permuting the values for that feature across all the examples, 
so that each example now has a random value for the feature and the original values for all other features\.
The evaluation metric \(e\.g\. R\-squared\) is then calculated for this modified dataset, 
and the change in the evaluation metric from the original dataset is computed\. 
The larger the change in the evaluation metric, the more important the feature is to the model\.

PFI typically takes a long time to compute, as the evaluation metric is calculated 
many times to determine the importance of each feature\.

```csharp
public static System.Collections.Generic.List<System.Tuple<string,double>> CalculatePFI(Microsoft.ML.MLContext mlContext, Microsoft.ML.IDataView trainData, Microsoft.ML.ITransformer model, string labelColumnName);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.CalculatePFI(Microsoft.ML.MLContext,Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string).mlContext'></a>

`mlContext` [Microsoft\.ML\.MLContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.mlcontext 'Microsoft\.ML\.MLContext')

The common context for all ML\.NET operations\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.CalculatePFI(Microsoft.ML.MLContext,Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string).trainData'></a>

`trainData` [Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')

IDataView used to evaluate the model\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.CalculatePFI(Microsoft.ML.MLContext,Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string).model'></a>

`model` [Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')

Model to evaluate\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.CalculatePFI(Microsoft.ML.MLContext,Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string).labelColumnName'></a>

`labelColumnName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Label column being predicted\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Tuple&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.tuple-2 'System\.Tuple\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of each feature and its importance\.

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

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string)'></a>

## OrtoBuildingDetectionModel\.PlotRSquaredValues\(IDataView, ITransformer, string, string\) Method

R Squared is a measure of variation between the values predicted by the model and the true values\. 
In a "perfect" model, there would be no variation between predictions and true values\. 

Here we will plot the predicted values vs the true values for the trained model\. This RegressionChart\.html 
is then saved to the location specified by [folderPath](DiGi_GIS_ML.md#DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string).folderPath 'DiGi\_GIS\_ML\.OrtoBuildingDetectionModel\.PlotRSquaredValues\(Microsoft\.ML\.IDataView, Microsoft\.ML\.ITransformer, string, string\)\.folderPath')\. 

See more information on R Squared at https://en\.wikipedia\.org/wiki/Coefficient\_of\_determination\.

```csharp
public static void PlotRSquaredValues(Microsoft.ML.IDataView trainData, Microsoft.ML.ITransformer model, string labelColumnName, string folderPath);
```
#### Parameters

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string).trainData'></a>

`trainData` [Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')

IDataView used to train the model\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string).model'></a>

`model` [Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')

Model used for predictions\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string).labelColumnName'></a>

`labelColumnName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Name of the predicted label column\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.PlotRSquaredValues(Microsoft.ML.IDataView,Microsoft.ML.ITransformer,string,string).folderPath'></a>

`folderPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Folder path to save the RegressionChart\.html file into\.

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