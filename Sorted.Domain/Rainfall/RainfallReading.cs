namespace Sorted.Domain.Rainfall
{
    /// <summary>
    /// Details of a rainfall reading 
    /// </summary>
    public class RainfallReading
    {
        public DateTime dateMeasured { get; set; }
        public decimal amountMeasured { get; set; }
    }
}