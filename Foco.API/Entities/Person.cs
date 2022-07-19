using Foco.API.Entities.BaseEntity;
using Foco.API.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Foco.API.Entities
{
    public class Person : Entity
    {
        public string Tz { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public int QueueNumber { get; set; }
        public int SiteId { get; set; }
        public PatientStatus PatientStatus { get; set; }
    }
}
