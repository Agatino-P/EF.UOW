using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.UOW.Inftrastructure.ContextOne;

public class RepositoryOne
{
    private readonly FirstDbContext dbContextOne;

    public RepositoryOne(FirstDbContext dbContextOne)
    {
        this.dbContextOne = dbContextOne;
    }
    public void Add(EntityOne entityOne)
    {
        dbContextOne.T1.Add(entityOne);
    }
}
