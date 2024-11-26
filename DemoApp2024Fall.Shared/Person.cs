using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp2024Fall.Shared;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Range(typeof(DateOnly), "1990-01-01", "2000-12-31")]
    public DateOnly BirthDate { get; set; }
    
    public virtual ICollection<Item> Items { get; set; }
}