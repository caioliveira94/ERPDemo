
using ERPDemo.Domain.Entities;
using System.Collections.Generic;

namespace ERPDemo.API.ViewModels
{
    public class GrupoVMGet
    {
        public string Nome { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
