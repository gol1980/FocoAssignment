using System;
using System.Runtime.Serialization;

namespace Foco.API.Entities.BaseEntity
{
    public class Entity
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
