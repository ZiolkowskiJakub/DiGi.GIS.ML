using DiGi.Core.Classes;
using System.Collections.Generic;
using System.IO;

namespace DiGi_GIS_ML
{
    /// <summary>
    /// Readiness surface for the generated model, kept in a partial the Model Builder does not own so a retrain does not revert it.
    /// <para>A hand-fix inside OrtoBuildingDetectionModel.consumption.cs would be regenerated away on the next retrain; a sibling partial is where the correction survives. Its one dependency - the hand-maintained private MLNetModelPath - is recorded in OrtoBuildingDetectionModel.provenance.md so a retrain re-establishes it.</para>
    /// <para><see cref="TrainedYears"/> and <see cref="TrainedRadiuses"/> record the contract the model was trained under. A retrain must update both, or the orchestrator refuses runs whose options match the old range and the <c>FeatureContract</c> fact fails against the regenerated <c>ModelInput</c>.</para>
    /// </summary>
    public partial class OrtoBuildingDetectionModel
    {
        /// <summary>Gets whether the trained model file is present at the resolved path.</summary>
        public static bool IsModelAvailable => File.Exists(MLNetModelPath);

        /// <summary>Gets the resolved model path, for the diagnostic when it is not present.</summary>
        public static string ResolvedModelPath => MLNetModelPath;

        /// <summary>Gets the year range this model was trained on. A retrain must update this, together with <see cref="TrainedRadiuses"/>.</summary>
        public static Range<int> TrainedYears { get; } = new(2008, 2025);

        /// <summary>Gets the radiuses, in metres, this model was trained on. A retrain must update this, together with <see cref="TrainedYears"/>.</summary>
        public static List<double> TrainedRadiuses { get; } = [200, 400, 600, 1000];
    }
}
