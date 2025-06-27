using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackendRemis.Infrastructure.Repositories
{
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
