using CudOperations.Data;
using CudOperations.Interfaces;
using CudOperations.Models;

namespace CudOperations.Implementaions;

public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
{

    public DepartmentRepository(AppDbContext context) : base(context)   
    {
    }
}