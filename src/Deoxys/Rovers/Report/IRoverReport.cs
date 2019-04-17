namespace Deoxys.Rovers.Report
{
    /// <summary>
    /// raporlama içşin kullanılcak olan tüm classların türetileceği arayüz
    /// </summary>
    public interface IRoverReport
    {

        /// <summary>
        /// raporlanacak rover aracı
        /// </summary>
        /// <value></value>
        IRover Rover { get; }

        /// <summary>
        /// tam raporlama işlemini gerçekleştirir
        /// </summary>
        void Write();

        /// <summary>
        /// rover aracının lokasyon raporlama işlemini yapar
        /// </summary>
        void LocationWrite();

    }
}