using System.ComponentModel.DataAnnotations;

namespace Tarefas.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Titulo { get; set; }
    
    [Required]
    [MaxLength(250)]
    [MinLength(10)]
    public string Descricao { get; set; }
}