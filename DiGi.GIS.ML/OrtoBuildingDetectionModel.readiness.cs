using System.IO;

namespace DiGi_GIS_ML
{
    /// <summary>
    /// Readiness surface for the generated model, kept in a partial the Model Builder does not own so a retrain does not revert it.
    /// <para>A hand-fix inside OrtoBuildingDetectionModel.consumption.cs would be regenerated away on the next retrain; a sibling partial is where the correction survives. Its one dependency - the hand-maintained private MLNetModelPath - is recorded in OrtoBuildingDetectionModel.provenance.md so a retrain re-establishes it.</para>
    /// </summary>
    public partial class OrtoBuildingDetectionModel
    {
        /// <summary>Gets whether the trained model file is present at the resolved path.</summary>
        public static bool IsModelAvailable => File.Exists(MLNetModelPath);

        /// <summary>Gets the resolved model path, for the diagnostic when it is not present.</summary>
        public static string ResolvedModelPath => MLNetModelPath;
    }
}
