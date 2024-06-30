namespace EF.UOW.Inftrastructure.ContextOne;

public class RepositoryTwo
{
    private readonly FirstDbContext dbContextOne;

    public RepositoryTwo(FirstDbContext dbContextOne)
    {
        this.dbContextOne = dbContextOne;
    }
    public void Add(EntityTwo entityTwo)
    {
        dbContextOne.T2.Add(entityTwo);
    }
}
