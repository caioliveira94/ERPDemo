using ERPDemo.Domain.Entities;
using ERPDemo.Domain.Interfaces.DataAccess;
using ERPDemo.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERPDemo.ApplicationService
{
    public class GrupoService : BaseService<Grupo, long>, IGrupoService
    {
        private readonly IGrupoRepository _repository;
        public GrupoService(IGrupoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
