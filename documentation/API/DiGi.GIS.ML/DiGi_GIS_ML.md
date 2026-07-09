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

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainAllowQuoting'></a>

## OrtoBuildingDetectionModel\.RetrainAllowQuoting Field

Indicates whether quoting is allowed in the retraining dataset file\.

```csharp
public const bool RetrainAllowQuoting = False;
```

#### Field Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainFilePath'></a>

## OrtoBuildingDetectionModel\.RetrainFilePath Field

The path to the training dataset used for retraining the model\.

```csharp
public const string RetrainFilePath = "C:\Users\jakub\GitHub\DigiProject\DiGi.GIS.ML\Data\Data_2025.05.27.tsv";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainHasHeader'></a>

## OrtoBuildingDetectionModel\.RetrainHasHeader Field

Indicates whether the retraining dataset file contains a header row\.

```csharp
public const bool RetrainHasHeader = True;
```

#### Field Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainSeparatorChar'></a>

## OrtoBuildingDetectionModel\.RetrainSeparatorChar Field

The separator character used in the retraining dataset file\.

```csharp
public const char RetrainSeparatorChar = '	';
```

#### Field Value
[System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')
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

The common context for all ML\.NET operations\.

#### Returns
[Microsoft\.ML\.IEstimator&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.iestimator-1 'Microsoft\.ML\.IEstimator\`1')[Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.iestimator-1 'Microsoft\.ML\.IEstimator\`1')  
The training pipeline as an [Microsoft\.ML\.IEstimator&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.iestimator-1 'Microsoft\.ML\.IEstimator\`1')\.

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

The path to the folder where the regression chart HTML file will be saved\.

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

The common context for all ML\.NET operations\.

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.RetrainModel(Microsoft.ML.MLContext,Microsoft.ML.IDataView).trainData'></a>

`trainData` [Microsoft\.ML\.IDataView](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.idataview 'Microsoft\.ML\.IDataView')

The training dataset to use for retraining the model\.

#### Returns
[Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')  
The retrained machine learning model as an [Microsoft\.ML\.ITransformer](https://learn.microsoft.com/en-us/dotnet/api/microsoft.ml.itransformer 'Microsoft\.ML\.ITransformer')\.

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
public static void Train(string outputModelPath, string inputDataFilePath="C:\\Users\\jakub\\GitHub\\DigiProject\\DiGi.GIS.ML\\Data\\Data_2025.05.27.tsv", char separatorChar='\t', bool hasHeader=true, bool allowQuoting=false);
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

model input class for OrtoBuildingDetectionModel\.

```csharp
public class OrtoBuildingDetectionModel.ModelInput
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelInput
### Properties

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Area'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Area Property

Gets or sets the area\.

```csharp
public float Area { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.BoundingBox_Height'></a>

## OrtoBuildingDetectionModel\.ModelInput\.BoundingBox\_Height Property

Gets or sets the BoundingBox Height\.

```csharp
public float BoundingBox_Height { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.BoundingBox_Width'></a>

## OrtoBuildingDetectionModel\.ModelInput\.BoundingBox\_Width Property

Gets or sets the BoundingBox Width\.

```csharp
public float BoundingBox_Width { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.BoundingBox_X'></a>

## OrtoBuildingDetectionModel\.ModelInput\.BoundingBox\_X Property

Gets or sets the BoundingBox X\.

```csharp
public float BoundingBox_X { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.BoundingBox_Y'></a>

## OrtoBuildingDetectionModel\.ModelInput\.BoundingBox\_Y Property

Gets or sets the BoundingBox Y\.

```csharp
public float BoundingBox_Y { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Building_General_Function'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Building\_General\_Function Property

Gets or sets the Building General Function\.

```csharp
public float Building_General_Function { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Building_Phase'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Building\_Phase Property

Gets or sets the Building Phase\.

```csharp
public float Building_Phase { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.County'></a>

## OrtoBuildingDetectionModel\.ModelInput\.County Property

Gets or sets the County\.

```csharp
public float County { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Location_X'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Location\_X Property

Gets or sets the location X\-coordinate\.

```csharp
public float Location_X { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Location_Y'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Location\_Y Property

Gets or sets the location Y\-coordinate\.

```csharp
public float Location_Y { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Municipality'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Municipality Property

Gets or sets the Municipality\.

```csharp
public float Municipality { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2008 Property

Gets or sets the population value for the year 2008\.

```csharp
public float Polpulation_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2009 Property

Gets or sets the population value for the year 2009\.

```csharp
public float Polpulation_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2010 Property

Gets or sets the population value for the year 2010\.

```csharp
public float Polpulation_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2011 Property

Gets or sets the population value for the year 2011\.

```csharp
public float Polpulation_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2012 Property

Gets or sets the population value for the year 2012\.

```csharp
public float Polpulation_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2013 Property

Gets or sets the population value for the year 2013\.

```csharp
public float Polpulation_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2014 Property

Gets or sets the population value for the year 2014\.

```csharp
public float Polpulation_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2015 Property

Gets or sets the population value for the year 2015\.

```csharp
public float Polpulation_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2016 Property

Gets or sets the population value for the year 2016\.

```csharp
public float Polpulation_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2017 Property

Gets or sets the population value for the year 2017\.

```csharp
public float Polpulation_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2018 Property

Gets or sets the population value for the year 2018\.

```csharp
public float Polpulation_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2019 Property

Gets or sets the population value for the year 2019\.

```csharp
public float Polpulation_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2020 Property

Gets or sets the population value for the year 2020\.

```csharp
public float Polpulation_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2021 Property

Gets or sets the population value for the year 2021\.

```csharp
public float Polpulation_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2022 Property

Gets or sets the population value for the year 2022\.

```csharp
public float Polpulation_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2023 Property

Gets or sets the population value for the year 2023\.

```csharp
public float Polpulation_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2024 Property

Gets or sets the population value for the year 2024\.

```csharp
public float Polpulation_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Polpulation_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Polpulation\_2025 Property

Gets or sets the population value for the year 2025\.

```csharp
public float Polpulation_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2008 Property

Gets or sets the predicted bounding box height for the year 2008\.

```csharp
public float Prediction_BoundingBox_Height_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2009 Property

Gets or sets the predicted bounding box height for the year 2009\.

```csharp
public float Prediction_BoundingBox_Height_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2010 Property

Gets or sets the predicted bounding box height for the year 2010\.

```csharp
public float Prediction_BoundingBox_Height_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2011 Property

Gets or sets the predicted bounding box height for the year 2011\.

```csharp
public float Prediction_BoundingBox_Height_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2012 Property

Gets or sets the predicted bounding box height for the year 2012\.

```csharp
public float Prediction_BoundingBox_Height_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2013 Property

Gets or sets the predicted bounding box height for the year 2013\.

```csharp
public float Prediction_BoundingBox_Height_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2014 Property

Gets or sets the predicted bounding box height for the year 2014\.

```csharp
public float Prediction_BoundingBox_Height_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2015 Property

Gets or sets the predicted bounding box height for the year 2015\.

```csharp
public float Prediction_BoundingBox_Height_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2016 Property

Gets or sets the predicted bounding box height for the year 2016\.

```csharp
public float Prediction_BoundingBox_Height_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2017 Property

Gets or sets the predicted bounding box height for the year 2017\.

```csharp
public float Prediction_BoundingBox_Height_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2018 Property

Gets or sets the predicted bounding box height for the year 2018\.

```csharp
public float Prediction_BoundingBox_Height_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2019 Property

Gets or sets the predicted bounding box height for the year 2019\.

```csharp
public float Prediction_BoundingBox_Height_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2020 Property

Gets or sets the predicted bounding box height for the year 2020\.

```csharp
public float Prediction_BoundingBox_Height_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2021 Property

Gets or sets the predicted bounding box height for the year 2021\.

```csharp
public float Prediction_BoundingBox_Height_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2022 Property

Gets or sets the predicted bounding box height for the year 2022\.

```csharp
public float Prediction_BoundingBox_Height_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2023 Property

Gets or sets the predicted bounding box height for the year 2023\.

```csharp
public float Prediction_BoundingBox_Height_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2024 Property

Gets or sets the predicted bounding box height for the year 2024\.

```csharp
public float Prediction_BoundingBox_Height_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Height_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Height\_2025 Property

Gets or sets the predicted bounding box height for the year 2025\.

```csharp
public float Prediction_BoundingBox_Height_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2008 Property

Gets or sets the predicted bounding box width for the year 2008\.

```csharp
public float Prediction_BoundingBox_Width_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2009 Property

Gets or sets the predicted bounding box width for the year 2009\.

```csharp
public float Prediction_BoundingBox_Width_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2010 Property

Gets or sets the predicted bounding box width for the year 2010\.

```csharp
public float Prediction_BoundingBox_Width_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2011 Property

Gets or sets the predicted bounding box width for the year 2011\.

```csharp
public float Prediction_BoundingBox_Width_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2012 Property

Gets or sets the predicted bounding box width for the year 2012\.

```csharp
public float Prediction_BoundingBox_Width_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2013 Property

Gets or sets the predicted bounding box width for the year 2013\.

```csharp
public float Prediction_BoundingBox_Width_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2014 Property

Gets or sets the predicted bounding box width for the year 2014\.

```csharp
public float Prediction_BoundingBox_Width_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2015 Property

Gets or sets the predicted bounding box width for the year 2015\.

```csharp
public float Prediction_BoundingBox_Width_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2016 Property

Gets or sets the predicted bounding box width for the year 2016\.

```csharp
public float Prediction_BoundingBox_Width_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2017 Property

Gets or sets the predicted bounding box width for the year 2017\.

```csharp
public float Prediction_BoundingBox_Width_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2018 Property

Gets or sets the predicted bounding box width for the year 2018\.

```csharp
public float Prediction_BoundingBox_Width_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2019 Property

Gets or sets the predicted bounding box width for the year 2019\.

```csharp
public float Prediction_BoundingBox_Width_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2020 Property

Gets or sets the predicted bounding box width for the year 2020\.

```csharp
public float Prediction_BoundingBox_Width_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2021 Property

Gets or sets the predicted bounding box width for the year 2021\.

```csharp
public float Prediction_BoundingBox_Width_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2022 Property

Gets or sets the predicted bounding box width for the year 2022\.

```csharp
public float Prediction_BoundingBox_Width_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2023 Property

Gets or sets the predicted bounding box width for the year 2023\.

```csharp
public float Prediction_BoundingBox_Width_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2024 Property

Gets or sets the predicted bounding box width for the year 2024\.

```csharp
public float Prediction_BoundingBox_Width_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Width_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Width\_2025 Property

Gets or sets the predicted bounding box width for the year 2025\.

```csharp
public float Prediction_BoundingBox_Width_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2008 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2008\.

```csharp
public float Prediction_BoundingBox_X_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2009 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2009\.

```csharp
public float Prediction_BoundingBox_X_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2010 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2010\.

```csharp
public float Prediction_BoundingBox_X_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2011 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2011\.

```csharp
public float Prediction_BoundingBox_X_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2012 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2012\.

```csharp
public float Prediction_BoundingBox_X_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2013 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2013\.

```csharp
public float Prediction_BoundingBox_X_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2014 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2014\.

```csharp
public float Prediction_BoundingBox_X_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2015 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2015\.

```csharp
public float Prediction_BoundingBox_X_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2016 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2016\.

```csharp
public float Prediction_BoundingBox_X_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2017 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2017\.

```csharp
public float Prediction_BoundingBox_X_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2018 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2018\.

```csharp
public float Prediction_BoundingBox_X_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2019 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2019\.

```csharp
public float Prediction_BoundingBox_X_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2020 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2020\.

```csharp
public float Prediction_BoundingBox_X_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2021 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2021\.

```csharp
public float Prediction_BoundingBox_X_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2022 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2022\.

```csharp
public float Prediction_BoundingBox_X_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2023 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2023\.

```csharp
public float Prediction_BoundingBox_X_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2024 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2024\.

```csharp
public float Prediction_BoundingBox_X_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_X_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_X\_2025 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2025\.

```csharp
public float Prediction_BoundingBox_X_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2008 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2008\.

```csharp
public float Prediction_BoundingBox_Y_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2009 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2009\.

```csharp
public float Prediction_BoundingBox_Y_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2010 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2010\.

```csharp
public float Prediction_BoundingBox_Y_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2011 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2011\.

```csharp
public float Prediction_BoundingBox_Y_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2012 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2012\.

```csharp
public float Prediction_BoundingBox_Y_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2013 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2013\.

```csharp
public float Prediction_BoundingBox_Y_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2014 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2014\.

```csharp
public float Prediction_BoundingBox_Y_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2015 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2015\.

```csharp
public float Prediction_BoundingBox_Y_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2016 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2016\.

```csharp
public float Prediction_BoundingBox_Y_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2017 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2017\.

```csharp
public float Prediction_BoundingBox_Y_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2018 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2018\.

```csharp
public float Prediction_BoundingBox_Y_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2019 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2019\.

```csharp
public float Prediction_BoundingBox_Y_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2020 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2020\.

```csharp
public float Prediction_BoundingBox_Y_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2021 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2021\.

```csharp
public float Prediction_BoundingBox_Y_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2022 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2022\.

```csharp
public float Prediction_BoundingBox_Y_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2023 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2023\.

```csharp
public float Prediction_BoundingBox_Y_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2024 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2024\.

```csharp
public float Prediction_BoundingBox_Y_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_BoundingBox_Y_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_BoundingBox\_Y\_2025 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2025\.

```csharp
public float Prediction_BoundingBox_Y_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2008'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2008 Property

Gets or sets the prediction confidence value for the year 2008\.

```csharp
public float Prediction_Confidence_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2009'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2009 Property

Gets or sets the prediction confidence value for the year 2009\.

```csharp
public float Prediction_Confidence_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2010'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2010 Property

Gets or sets the prediction confidence value for the year 2010\.

```csharp
public float Prediction_Confidence_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2011'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2011 Property

Gets or sets the prediction confidence value for the year 2011\.

```csharp
public float Prediction_Confidence_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2012'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2012 Property

Gets or sets the prediction confidence value for the year 2012\.

```csharp
public float Prediction_Confidence_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2013'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2013 Property

Gets or sets the prediction confidence value for the year 2013\.

```csharp
public float Prediction_Confidence_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2014'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2014 Property

Gets or sets the prediction confidence value for the year 2014\.

```csharp
public float Prediction_Confidence_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2015'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2015 Property

Gets or sets the prediction confidence value for the year 2015\.

```csharp
public float Prediction_Confidence_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2016'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2016 Property

Gets or sets the prediction confidence value for the year 2016\.

```csharp
public float Prediction_Confidence_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2017'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2017 Property

Gets or sets the prediction confidence value for the year 2017\.

```csharp
public float Prediction_Confidence_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2018'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2018 Property

Gets or sets the prediction confidence value for the year 2018\.

```csharp
public float Prediction_Confidence_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2019'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2019 Property

Gets or sets the prediction confidence value for the year 2019\.

```csharp
public float Prediction_Confidence_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2020'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2020 Property

Gets or sets the prediction confidence value for the year 2020\.

```csharp
public float Prediction_Confidence_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2021'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2021 Property

Gets or sets the prediction confidence value for the year 2021\.

```csharp
public float Prediction_Confidence_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2022'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2022 Property

Gets or sets the prediction confidence value for the year 2022\.

```csharp
public float Prediction_Confidence_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2023'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2023 Property

Gets or sets the prediction confidence value for the year 2023\.

```csharp
public float Prediction_Confidence_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2024'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2024 Property

Gets or sets the prediction confidence value for the year 2024\.

```csharp
public float Prediction_Confidence_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Prediction_Confidence_2025'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Prediction\_Confidence\_2025 Property

Gets or sets the prediction confidence value for the year 2025\.

```csharp
public float Prediction_Confidence_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Storeys'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Storeys Property

Gets or sets the number of storeys\.

```csharp
public float Storeys { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Subdivision'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Subdivision Property

Gets or sets the Subdivision\.

```csharp
public float Subdivision { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Subdivision_Calculated_Occupancy'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Subdivision\_Calculated\_Occupancy Property

Gets or sets the Subdivision Calculated Occupancy\.

```csharp
public float Subdivision_Calculated_Occupancy { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Subdivision_Calculated_Occupancy_Area'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Subdivision\_Calculated\_Occupancy\_Area Property

Gets or sets the Subdivision Calculated Occupancy Area\.

```csharp
public float Subdivision_Calculated_Occupancy_Area { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Voivodeship'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Voivodeship Property

Gets or sets the Voivodeship\.

```csharp
public float Voivodeship { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelInput.Year_Built'></a>

## OrtoBuildingDetectionModel\.ModelInput\.Year\_Built Property

Gets or sets the year the building was built\.

```csharp
public float Year_Built { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput'></a>

## OrtoBuildingDetectionModel\.ModelOutput Class

model output class for OrtoBuildingDetectionModel\.

```csharp
public class OrtoBuildingDetectionModel.ModelOutput
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelOutput
### Properties

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Area'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Area Property

Gets or sets the area\.

```csharp
public float Area { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.BoundingBox_Height'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.BoundingBox\_Height Property

Gets or sets the BoundingBox Height\.

```csharp
public float BoundingBox_Height { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.BoundingBox_Width'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.BoundingBox\_Width Property

Gets or sets the BoundingBox Width\.

```csharp
public float BoundingBox_Width { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.BoundingBox_X'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.BoundingBox\_X Property

Gets or sets the BoundingBox X\.

```csharp
public float BoundingBox_X { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.BoundingBox_Y'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.BoundingBox\_Y Property

Gets or sets the BoundingBox Y\.

```csharp
public float BoundingBox_Y { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Building_General_Function'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Building\_General\_Function Property

Gets or sets the Building General Function\.

```csharp
public float Building_General_Function { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Building_Phase'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Building\_Phase Property

Gets or sets the Building Phase\.

```csharp
public float Building_Phase { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.County'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.County Property

Gets or sets the County\.

```csharp
public float County { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Features'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Features Property

Gets or sets the features vector used by the model\.

```csharp
public float[] Features { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Location_X'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Location\_X Property

Gets or sets the location X\-coordinate\.

```csharp
public float Location_X { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Location_Y'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Location\_Y Property

Gets or sets the location Y\-coordinate\.

```csharp
public float Location_Y { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Municipality'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Municipality Property

Gets or sets the Municipality\.

```csharp
public float Municipality { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2008 Property

Gets or sets the population value for the year 2008\.

```csharp
public float Polpulation_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2009 Property

Gets or sets the population value for the year 2009\.

```csharp
public float Polpulation_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2010 Property

Gets or sets the population value for the year 2010\.

```csharp
public float Polpulation_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2011 Property

Gets or sets the population value for the year 2011\.

```csharp
public float Polpulation_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2012 Property

Gets or sets the population value for the year 2012\.

```csharp
public float Polpulation_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2013 Property

Gets or sets the population value for the year 2013\.

```csharp
public float Polpulation_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2014 Property

Gets or sets the population value for the year 2014\.

```csharp
public float Polpulation_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2015 Property

Gets or sets the population value for the year 2015\.

```csharp
public float Polpulation_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2016 Property

Gets or sets the population value for the year 2016\.

```csharp
public float Polpulation_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2017 Property

Gets or sets the population value for the year 2017\.

```csharp
public float Polpulation_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2018 Property

Gets or sets the population value for the year 2018\.

```csharp
public float Polpulation_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2019 Property

Gets or sets the population value for the year 2019\.

```csharp
public float Polpulation_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2020 Property

Gets or sets the population value for the year 2020\.

```csharp
public float Polpulation_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2021 Property

Gets or sets the population value for the year 2021\.

```csharp
public float Polpulation_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2022 Property

Gets or sets the population value for the year 2022\.

```csharp
public float Polpulation_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2023 Property

Gets or sets the population value for the year 2023\.

```csharp
public float Polpulation_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2024 Property

Gets or sets the population value for the year 2024\.

```csharp
public float Polpulation_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Polpulation_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Polpulation\_2025 Property

Gets or sets the population value for the year 2025\.

```csharp
public float Polpulation_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2008 Property

Gets or sets the predicted bounding box height for the year 2008\.

```csharp
public float Prediction_BoundingBox_Height_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2009 Property

Gets or sets the predicted bounding box height for the year 2009\.

```csharp
public float Prediction_BoundingBox_Height_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2010 Property

Gets or sets the predicted bounding box height for the year 2010\.

```csharp
public float Prediction_BoundingBox_Height_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2011 Property

Gets or sets the predicted bounding box height for the year 2011\.

```csharp
public float Prediction_BoundingBox_Height_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2012 Property

Gets or sets the predicted bounding box height for the year 2012\.

```csharp
public float Prediction_BoundingBox_Height_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2013 Property

Gets or sets the predicted bounding box height for the year 2013\.

```csharp
public float Prediction_BoundingBox_Height_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2014 Property

Gets or sets the predicted bounding box height for the year 2014\.

```csharp
public float Prediction_BoundingBox_Height_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2015 Property

Gets or sets the predicted bounding box height for the year 2015\.

```csharp
public float Prediction_BoundingBox_Height_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2016 Property

Gets or sets the predicted bounding box height for the year 2016\.

```csharp
public float Prediction_BoundingBox_Height_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2017 Property

Gets or sets the predicted bounding box height for the year 2017\.

```csharp
public float Prediction_BoundingBox_Height_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2018 Property

Gets or sets the predicted bounding box height for the year 2018\.

```csharp
public float Prediction_BoundingBox_Height_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2019 Property

Gets or sets the predicted bounding box height for the year 2019\.

```csharp
public float Prediction_BoundingBox_Height_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2020 Property

Gets or sets the predicted bounding box height for the year 2020\.

```csharp
public float Prediction_BoundingBox_Height_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2021 Property

Gets or sets the predicted bounding box height for the year 2021\.

```csharp
public float Prediction_BoundingBox_Height_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2022 Property

Gets or sets the predicted bounding box height for the year 2022\.

```csharp
public float Prediction_BoundingBox_Height_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2023 Property

Gets or sets the predicted bounding box height for the year 2023\.

```csharp
public float Prediction_BoundingBox_Height_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2024 Property

Gets or sets the predicted bounding box height for the year 2024\.

```csharp
public float Prediction_BoundingBox_Height_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Height_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Height\_2025 Property

Gets or sets the predicted bounding box height for the year 2025\.

```csharp
public float Prediction_BoundingBox_Height_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2008 Property

Gets or sets the predicted bounding box width for the year 2008\.

```csharp
public float Prediction_BoundingBox_Width_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2009 Property

Gets or sets the predicted bounding box width for the year 2009\.

```csharp
public float Prediction_BoundingBox_Width_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2010 Property

Gets or sets the predicted bounding box width for the year 2010\.

```csharp
public float Prediction_BoundingBox_Width_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2011 Property

Gets or sets the predicted bounding box width for the year 2011\.

```csharp
public float Prediction_BoundingBox_Width_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2012 Property

Gets or sets the predicted bounding box width for the year 2012\.

```csharp
public float Prediction_BoundingBox_Width_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2013 Property

Gets or sets the predicted bounding box width for the year 2013\.

```csharp
public float Prediction_BoundingBox_Width_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2014 Property

Gets or sets the predicted bounding box width for the year 2014\.

```csharp
public float Prediction_BoundingBox_Width_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2015 Property

Gets or sets the predicted bounding box width for the year 2015\.

```csharp
public float Prediction_BoundingBox_Width_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2016 Property

Gets or sets the predicted bounding box width for the year 2016\.

```csharp
public float Prediction_BoundingBox_Width_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2017 Property

Gets or sets the predicted bounding box width for the year 2017\.

```csharp
public float Prediction_BoundingBox_Width_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2018 Property

Gets or sets the predicted bounding box width for the year 2018\.

```csharp
public float Prediction_BoundingBox_Width_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2019 Property

Gets or sets the predicted bounding box width for the year 2019\.

```csharp
public float Prediction_BoundingBox_Width_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2020 Property

Gets or sets the predicted bounding box width for the year 2020\.

```csharp
public float Prediction_BoundingBox_Width_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2021 Property

Gets or sets the predicted bounding box width for the year 2021\.

```csharp
public float Prediction_BoundingBox_Width_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2022 Property

Gets or sets the predicted bounding box width for the year 2022\.

```csharp
public float Prediction_BoundingBox_Width_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2023 Property

Gets or sets the predicted bounding box width for the year 2023\.

```csharp
public float Prediction_BoundingBox_Width_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2024 Property

Gets or sets the predicted bounding box width for the year 2024\.

```csharp
public float Prediction_BoundingBox_Width_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Width_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Width\_2025 Property

Gets or sets the predicted bounding box width for the year 2025\.

```csharp
public float Prediction_BoundingBox_Width_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2008 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2008\.

```csharp
public float Prediction_BoundingBox_X_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2009 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2009\.

```csharp
public float Prediction_BoundingBox_X_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2010 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2010\.

```csharp
public float Prediction_BoundingBox_X_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2011 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2011\.

```csharp
public float Prediction_BoundingBox_X_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2012 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2012\.

```csharp
public float Prediction_BoundingBox_X_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2013 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2013\.

```csharp
public float Prediction_BoundingBox_X_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2014 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2014\.

```csharp
public float Prediction_BoundingBox_X_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2015 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2015\.

```csharp
public float Prediction_BoundingBox_X_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2016 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2016\.

```csharp
public float Prediction_BoundingBox_X_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2017 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2017\.

```csharp
public float Prediction_BoundingBox_X_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2018 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2018\.

```csharp
public float Prediction_BoundingBox_X_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2019 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2019\.

```csharp
public float Prediction_BoundingBox_X_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2020 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2020\.

```csharp
public float Prediction_BoundingBox_X_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2021 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2021\.

```csharp
public float Prediction_BoundingBox_X_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2022 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2022\.

```csharp
public float Prediction_BoundingBox_X_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2023 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2023\.

```csharp
public float Prediction_BoundingBox_X_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2024 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2024\.

```csharp
public float Prediction_BoundingBox_X_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_X_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_X\_2025 Property

Gets or sets the predicted bounding box X\-coordinate for the year 2025\.

```csharp
public float Prediction_BoundingBox_X_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2008 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2008\.

```csharp
public float Prediction_BoundingBox_Y_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2009 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2009\.

```csharp
public float Prediction_BoundingBox_Y_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2010 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2010\.

```csharp
public float Prediction_BoundingBox_Y_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2011 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2011\.

```csharp
public float Prediction_BoundingBox_Y_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2012 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2012\.

```csharp
public float Prediction_BoundingBox_Y_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2013 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2013\.

```csharp
public float Prediction_BoundingBox_Y_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2014 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2014\.

```csharp
public float Prediction_BoundingBox_Y_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2015 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2015\.

```csharp
public float Prediction_BoundingBox_Y_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2016 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2016\.

```csharp
public float Prediction_BoundingBox_Y_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2017 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2017\.

```csharp
public float Prediction_BoundingBox_Y_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2018 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2018\.

```csharp
public float Prediction_BoundingBox_Y_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2019 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2019\.

```csharp
public float Prediction_BoundingBox_Y_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2020 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2020\.

```csharp
public float Prediction_BoundingBox_Y_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2021 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2021\.

```csharp
public float Prediction_BoundingBox_Y_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2022 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2022\.

```csharp
public float Prediction_BoundingBox_Y_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2023 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2023\.

```csharp
public float Prediction_BoundingBox_Y_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2024 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2024\.

```csharp
public float Prediction_BoundingBox_Y_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_BoundingBox_Y_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_BoundingBox\_Y\_2025 Property

Gets or sets the predicted bounding box Y\-coordinate for the year 2025\.

```csharp
public float Prediction_BoundingBox_Y_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2008'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2008 Property

Gets or sets the prediction confidence value for the year 2008\.

```csharp
public float Prediction_Confidence_2008 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2009'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2009 Property

Gets or sets the prediction confidence value for the year 2009\.

```csharp
public float Prediction_Confidence_2009 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2010'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2010 Property

Gets or sets the prediction confidence value for the year 2010\.

```csharp
public float Prediction_Confidence_2010 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2011'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2011 Property

Gets or sets the prediction confidence value for the year 2011\.

```csharp
public float Prediction_Confidence_2011 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2012'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2012 Property

Gets or sets the prediction confidence value for the year 2012\.

```csharp
public float Prediction_Confidence_2012 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2013'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2013 Property

Gets or sets the prediction confidence value for the year 2013\.

```csharp
public float Prediction_Confidence_2013 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2014'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2014 Property

Gets or sets the prediction confidence value for the year 2014\.

```csharp
public float Prediction_Confidence_2014 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2015'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2015 Property

Gets or sets the prediction confidence value for the year 2015\.

```csharp
public float Prediction_Confidence_2015 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2016'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2016 Property

Gets or sets the prediction confidence value for the year 2016\.

```csharp
public float Prediction_Confidence_2016 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2017'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2017 Property

Gets or sets the prediction confidence value for the year 2017\.

```csharp
public float Prediction_Confidence_2017 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2018'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2018 Property

Gets or sets the prediction confidence value for the year 2018\.

```csharp
public float Prediction_Confidence_2018 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2019'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2019 Property

Gets or sets the prediction confidence value for the year 2019\.

```csharp
public float Prediction_Confidence_2019 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2020'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2020 Property

Gets or sets the prediction confidence value for the year 2020\.

```csharp
public float Prediction_Confidence_2020 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2021'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2021 Property

Gets or sets the prediction confidence value for the year 2021\.

```csharp
public float Prediction_Confidence_2021 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2022'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2022 Property

Gets or sets the prediction confidence value for the year 2022\.

```csharp
public float Prediction_Confidence_2022 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2023'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2023 Property

Gets or sets the prediction confidence value for the year 2023\.

```csharp
public float Prediction_Confidence_2023 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2024'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2024 Property

Gets or sets the prediction confidence value for the year 2024\.

```csharp
public float Prediction_Confidence_2024 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Prediction_Confidence_2025'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Prediction\_Confidence\_2025 Property

Gets or sets the prediction confidence value for the year 2025\.

```csharp
public float Prediction_Confidence_2025 { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Score'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Score Property

Gets or sets the prediction score\.

```csharp
public float Score { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Storeys'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Storeys Property

Gets or sets the number of storeys\.

```csharp
public float Storeys { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Subdivision'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Subdivision Property

Gets or sets the Subdivision\.

```csharp
public float Subdivision { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Subdivision_Calculated_Occupancy'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Subdivision\_Calculated\_Occupancy Property

Gets or sets the Subdivision Calculated Occupancy\.

```csharp
public float Subdivision_Calculated_Occupancy { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Subdivision_Calculated_Occupancy_Area'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Subdivision\_Calculated\_Occupancy\_Area Property

Gets or sets the Subdivision Calculated Occupancy Area\.

```csharp
public float Subdivision_Calculated_Occupancy_Area { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Voivodeship'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Voivodeship Property

Gets or sets the Voivodeship\.

```csharp
public float Voivodeship { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')

<a name='DiGi_GIS_ML.OrtoBuildingDetectionModel.ModelOutput.Year_Built'></a>

## OrtoBuildingDetectionModel\.ModelOutput\.Year\_Built Property

Gets or sets the year the building was built\.

```csharp
public float Year_Built { get; set; }
```

#### Property Value
[System\.Single](https://learn.microsoft.com/en-us/dotnet/api/system.single 'System\.Single')