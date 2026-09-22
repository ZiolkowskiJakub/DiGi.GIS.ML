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

        /// <summary>
        /// The page size of the keyset-paged label read.
        /// <para>The label read projects the single <c>User year built</c> column beside the <c>Reference</c> and <c>County Id</c> the server always adds, so a page is light and well under the endpoint&apos;s <c>PageSize</c> cap of 10 000. A 3-column page at 5 000 rows is small enough to keep the request fast without paging a county in a hundred calls.</para>
        /// </summary>
        public const int Row_Maximum = 5000;
    }
}
