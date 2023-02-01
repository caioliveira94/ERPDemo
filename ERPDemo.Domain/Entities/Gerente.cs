using ERPDemo.Domain.Entities.Enum;

namespace ERPDemo.Domain.Entities
{
    public class Gerente : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Nivel { get; set; }
    }
}
