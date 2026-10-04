namespace GolBet.Entities.Common;
 
/// <summary>
/// Base class for all domain entities.
/// Provides identity, audit timestamps and logical activation state.
/// </summary>
/// Abstract is to be inherited and never be main or direct instance.
/// The only function is to be:
///  - a builder for other entities
public abstract class AuditableEntity
{
    public int Id { get; set; }
 
    /// <summary>Set automatically when the entity is first saved.</summary>
    public DateTime CreatedDate { get; set; }
 
    /// <summary>Set automatically on every update. Null until first modification.</summary>
    public DateTime? ModifiedDate { get; set; }
 
    /// <summary>Logical state. Inactive entities are hidden, not deleted.</summary>
    public bool IsActive { get; set; } = true;
}