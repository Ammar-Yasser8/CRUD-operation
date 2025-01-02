using System.ComponentModel.DataAnnotations;

namespace CudOperations.Models;

public class Empolyee
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }  
    
}