namespace HBS.Data.Entities.SchedulingTimeTracking.Models
{
    public interface IExportPage
    {
        void ExportExcel(string data, string fileName);
    }
}
