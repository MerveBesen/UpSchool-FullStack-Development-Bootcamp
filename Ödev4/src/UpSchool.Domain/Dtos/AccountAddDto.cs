using System.ComponentModel.DataAnnotations;

namespace UpSchool.Domain.Dtos;

public class AccountAddDto
{
    [Required(ErrorMessage = "{0} field is required.")]       //Required kısmı zorunlu alan olduğunu belirtir. İç kısmına () ile eror message yazılabilir ve yazarken {0} koyulduğunda alanın adını döndürür. Örnek olrak bunda title döner.
    public string Title { get; set; }       // Attribute kısımları olarak üzerinde yazılanları alır.
    
    [Required]
    [MaxLength(40)]
    [MinLength(2)]
    public string UserName { get; set; }
    
    [Required]
    [MaxLength(40)]
    [MinLength(6)]
    public string Password { get; set; }
    
    public string? Url { get; set; }        // ? koyduğumuzda nullable olur yani değer verilmeyedebilir.
   
    [Required]
    public bool IsFavourite { get; set; }
    
    public string ConnectionId { get; set; }
}