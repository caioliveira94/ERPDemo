
using System;
using System.Text.Json.Serialization;

namespace ERPDemo.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        
        [JsonIgnore]
        public virtual Grupo Grupo { get; set; }
    }
}
