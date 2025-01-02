using CudOperations.Data;
using CudOperations.Interfaces;
using CudOperations.Models;

namespace CudOperations.Implementaions;

public class EmpolyeeRepository : GenericRepository<Empolyee>, IEmpolyeeRepository
{
    public EmpolyeeRepository(AppDbContext context):base(context)
    {
    }
}