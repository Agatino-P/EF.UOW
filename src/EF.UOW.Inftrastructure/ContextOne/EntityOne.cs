using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.UOW.Inftrastructure.ContextOne;
public class EntityOne
{
    public Guid Id { get; set; }

    public EntityOne() : this(Guid.NewGuid()) { }

    public EntityOne(Guid id) => Id = id;
}
