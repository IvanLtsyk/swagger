using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiCore.Data.Domain
{
    public abstract class IdentifibleEntityIntBase : IIdentifiableEntity<int>
    {
        [Key]
        public int Id { get; set; }
    }
}
