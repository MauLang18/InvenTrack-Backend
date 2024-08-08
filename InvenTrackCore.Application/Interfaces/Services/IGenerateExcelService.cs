namespace InvenTrackCore.Application.Interfaces.Services;

public interface IGenerateExcelService
{
    byte[] GenerateExcel<T>(IEnumerable<T> data, List<(string ColumnName, string PropertyName)> columns);
}