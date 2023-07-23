namespace Domain.Common;

public interface IEntityBase<TKey>
{
    TKey Id { get; set; }
    
    DateTimeOffset CreatedOn { get; set; }
}