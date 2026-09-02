namespace DiGi.GIS.ML.ConsoleApp.Constants
{
    /// <summary>
    /// Provides the request size limits the deployed WebAPI enforces.
    /// </summary>
    public static class Count
    {
        /// <summary>
        /// The greatest number of references either bulk endpoint accepts in one request.
        /// <para>Mirrors <c>referenceCount_Maximum</c> on <c>BuildingDataController</c> and <c>YearBuiltDataController</c>. A larger page is refused outright rather than merely being slower, and it fails the whole page, so the caller pages to this rather than discovering it from a 400.</para>
        /// </summary>
        public const int Reference_Maximum = 10000;
    }
}
