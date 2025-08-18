namespace OnTime.Domain.Entities;

public class SqlDataConnectionDescription : DataConnection { }

public abstract class DataConnection
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}

public class ReportItem
{
    public int Id { get; set; }
    public bool IsPublic { get; set; }
    public long? EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Filters { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public byte[] LayoutData { get; set; } = Array.Empty<byte>();
}

