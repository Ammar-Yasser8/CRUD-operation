using CudOperations.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudOperations.ViewModels
{
    public class EmployeeDepartmentVM
    {
        public Empolyee Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DepartmentList { get; set; }    
    }
}
