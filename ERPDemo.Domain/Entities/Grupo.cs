using System.Collections.Generic;

namespace ERPDemo.Domain.Entities
{
    public class Grupo : EntityBase
    {
        public Grupo()
        {
            
        }
        public string Nome { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
