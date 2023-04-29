using System;

namespace GTERP.Models
{
    public class CompanyUser
    {
        public Guid ComId { get; set; }
        public string CompanyName { get; set; }
        public bool isDefault { get; set; }
    }
}