using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCore.Data.Domain
{
    public interface IIdentifiableEntity<TKey>
    {
         TKey Id { get; set; }
    }
}
