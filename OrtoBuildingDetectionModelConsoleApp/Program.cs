using DiGi.Core.IO.DelimitedData;
using DiGi.Core.IO.DelimitedData.Enums;
using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.ML;
using System;
using System.IO;

string? path_Input = null;
string? path_Output = null;

for (int i = 0; i < args.Length; i++)
{
    if ((string.Equals(args[i], "--input", StringComparison.OrdinalIgnoreCase) || string.Equals(args[i], "-i", StringComparison.OrdinalIgnoreCase)) && i + 1 < args.Length)
    {
        path_Input = args[++i];
    }
    else if ((string.Equals(args[i], "--output", StringComparison.OrdinalIgnoreCase) || string.Equals(args[i], "-o", StringComparison.OrdinalIgnoreCase)) && i + 1 < args.Length)
    {
        path_Output = args[++i];
    }
}

if (string.IsNullOrWhiteSpace(path_Input) || string.IsNullOrWhiteSpace(path_Output))
{
    Console.WriteLine("Usage: OrtoBuildingDetectionModelConsoleApp --input <path_to_input.tsv> --output <path_to_output.tsv>");
    return 1;
}

if (!File.Exists(path_Input))
{
    Console.WriteLine($"Input file does not exist: {path_Input}");
    return 1;
}

string? directory_Output = Path.GetDirectoryName(path_Output);
if (!string.IsNullOrWhiteSpace(directory_Output) && !Directory.Exists(directory_Output))
{
    Directory.CreateDirectory(directory_Output);
}

Table? table_Input = DiGi.Core.IO.DelimitedData.Create.Table(path_Input, DelimitedDataSeparator.Tab);
if (table_Input is null)
{
    Console.WriteLine($"Failed to load tabular data from: {path_Input}");
    return 1;
}

Table? table_Output = table_Input.PredictedYearBuilts();
if (table_Output is null)
{
    Console.WriteLine("Failed to compute predicted year built values.");
    return 1;
}

bool isSuccess = table_Output.Write(path_Output, DelimitedDataSeparator.Tab);
if (!isSuccess)
{
    Console.WriteLine($"Failed to write output table to: {path_Output}");
    return 1;
}

Console.WriteLine($"Successfully predicted {table_Output.RowCount} building rows and saved to: {path_Output}");
return 0;
