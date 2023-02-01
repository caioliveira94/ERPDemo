using ERPDemo.ApplicationService;
using ERPDemo.Data.Contexts;
using ERPDemo.Data.Repositories;
using ERPDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ERPDemo.Tests.Api.Services
{
    public class GrupoServiceTest
    {
        private GrupoService _appService;
        private GrupoRepository _repository;
        public GrupoServiceTest()
        {
            _repository = new GrupoRepository(GenerateFakeData());
            _appService = new GrupoService(_repository);
        }

        private ApplicationDbContext GenerateFakeData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "ErpDemoDb")
            .Options;

            var context = new ApplicationDbContext(options);

            var grpNacionais = new Grupo { Id = 1, Nome = "Nacionais", CreationDate = DateTime.Now };
            var grpInternacionais = new Grupo { Id = 2, Nome = "Importados", CreationDate = DateTime.Now };

            context.Grupos.Add(grpNacionais);
            context.Grupos.Add(grpInternacionais);

            context.Clientes.Add(new Cliente { Id = 1, Nome = "Scania", CNPJ = "123456789", DataFundacao = new DateTime(1950,1,1), Grupo = grpNacionais, CreationDate = DateTime.Now });
            context.Clientes.Add(new Cliente { Id = 2, Nome = "Volks", CNPJ = "2223334445", DataFundacao = new DateTime(1971, 2, 1), Grupo = grpNacionais, CreationDate = DateTime.Now });
            context.Clientes.Add(new Cliente { Id = 3, Nome = "Mercedes", CNPJ = "999999999", DataFundacao = new DateTime(1985, 3, 1), Grupo = grpInternacionais, CreationDate = DateTime.Now });

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetAllGrupos()
        {
            var result = await _appService.GetAllAsync();

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public async Task GetClientesGrupo()
        {
            var result = await _appService.GetByIdAsync(1);

            Assert.True(result.Clientes.Count() == 2);
        }
    }
}
