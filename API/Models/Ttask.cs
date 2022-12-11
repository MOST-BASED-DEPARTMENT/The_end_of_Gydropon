namespace API.Models;

public partial class Ttask
{
    public int IdTtask { get; set; }

    public int? TtaskExecutorId { get; set; }

    public int TtaskFieldId { get; set; }

    public int TtaskTypeId { get; set; }

    public int TtaskStatusId { get; set; }

    public DateTime TtaskDate { get; set; }

    public TimeSpan? TtaskStartTime { get; set; }

    public TimeSpan? TtaskFinishingTime { get; set; }

    public string? TtaskDescription { get; set; }

    public string? TtaskWeatherInfo { get; set; }

    public virtual User? TtaskExecutor { get; set; }

    public virtual Field TtaskField { get; set; } = null!;

    public virtual TtaskStatus TtaskStatus { get; set; } = null!;

    public virtual TtaskType TtaskType { get; set; } = null!;
}
