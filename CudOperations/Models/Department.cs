using System.ComponentModel.DataAnnotations;

namespace CudOperations.Models;

public class Department
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; } 
}