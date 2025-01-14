namespace BudgetTracking.Domain.Models.Common;

public interface ITrackable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
}
