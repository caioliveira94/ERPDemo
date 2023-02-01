using ERPDemo.Data.Contexts;
using ERPDemo.Domain.Entities;
using ERPDemo.Domain.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ERPDemo.Data.Repositories
{
    public class GrupoRepository : BaseRepository<Grupo, long>, IGrupoRepository
    {
        public GrupoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Grupo> GetByIdAsync(long id)
        {
            return await applicationDbContext.Grupos.Include(x => x.Clientes).FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
