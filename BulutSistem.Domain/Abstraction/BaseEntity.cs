using System.ComponentModel.DataAnnotations;

namespace BulutSistem.Domain.Abstraction;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; } = default!;
    public DateTime Created_At { get; set; } = DateTime.Now;  // best practise
    public DateTime Updated_At { get; set; } = DateTime.Now; //best practise
    public bool IsDeleted { get; set; } // soft delete için
}