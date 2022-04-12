using System;
using WebApiCore.Data.Domain;

namespace WebApiCore.Data.Models
{
    public  class Customer: IdentifibleEntityIntBase
    {
        public string  Name { get; set; }
        public string  Email { get; set; }
        public DateTime  BirthDate { get; set; }
    }
}
