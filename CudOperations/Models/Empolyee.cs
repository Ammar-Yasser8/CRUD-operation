using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CudOperations.Models;

public class Empolyee
{
    public int Id { get; set; }
    [Required (ErrorMessage ="The Name is required")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Department")]
    public int DepartmentId { get; set; }
    [ValidateNever]
    public Department Department { get; set; }  
    
}