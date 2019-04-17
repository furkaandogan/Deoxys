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

        /// <summary>
        /// raporlanmak istenen rover aracın bilgilerini setler
        /// </summary>
        /// <param name="rover">raporlanmak istenen rover</param>
        void SetRover(IRover rover);

    }
}