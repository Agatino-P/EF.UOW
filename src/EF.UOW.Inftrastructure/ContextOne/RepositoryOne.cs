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
        dbContextOne.SaveChanges();
    }

    public void CauseException(EntityOne entityOne)
    {
        dbContextOne.T1.Add(entityOne);

        EntityOne entityOneB = new(entityOne.Id);
        dbContextOne.T1.Add(entityOneB);

        dbContextOne.SaveChanges();
    }
}
