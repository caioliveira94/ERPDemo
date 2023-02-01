using System;

namespace ERPDemo.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        private DateTime CreatedAt;
        public DateTime CreationDate
        {
            get { return CreatedAt; }
            set { CreatedAt = DateTime.Now; }
        }
        public DateTime? LastUpdate { get; set; }
    }
}
