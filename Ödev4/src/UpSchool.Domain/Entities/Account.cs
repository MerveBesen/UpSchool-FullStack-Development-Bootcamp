namespace UpSchool.Domain.Entities;

public class Account
{
    
    public Guid Id { get; set; }        // Benzersiz(Guid) Id
    public string Title { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Url { get; set; }        // ? koyduğumuzda nullable olur yani değer verilmeyedebilir.
    public bool IsFavourite { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    
}