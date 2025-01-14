using System.Text.Json.Serialization;
using BudgetTracking.Domain.Models.Common;

namespace BudgetTracking.Domain.Models;

public class User : ModelBase
{
    public string Email { get; set; } = null!;

    [JsonIgnore]
    public string? Password { get; set; }
}
