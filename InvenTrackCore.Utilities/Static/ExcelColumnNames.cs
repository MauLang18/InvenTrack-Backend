namespace InvenTrackCore.Utilities.Static;

public class ExcelColumnNames
{
    public static List<TableColumns> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
    {
        var columns = new List<TableColumns>();

        foreach (var (ColumnName, PropertyName) in columnsProperties)
        {
            var column = new TableColumns()
            {
                Label = ColumnName,
                PropertyName = PropertyName
            };

            columns.Add(column);
        }

        return columns;
    }

    #region ColumnsInventory
    public static List<(string ColumnName, string PropertyName)> GetColumnsInventory()
    {
        var columnsProperties = new List<(string ColumnName, string PropertyName)>
        {
            ("ID", "InventoryId"),
            ("CÓDIGO", "Code"),
            ("ACTIVO", "Active"),
            ("TIPO DE EQUIPO", "EquipmentTypeName"),
            ("MARCA", "Brand"),
            ("MODELO", "Model"),
            ("SERIE", "Series"),
            ("PRECIO", "Price"),
            ("DETALLES", "Details"),
            ("IMAGEN", "Image"),
            ("FECHA DE CREACION", "AuditCreateDate"),
            ("ESTADO", "StateInventory"),
        };

        return columnsProperties;
    }
    #endregion
}