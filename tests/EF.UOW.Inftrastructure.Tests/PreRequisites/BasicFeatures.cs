using EF.UOW.Inftrastructure.ContextOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF.UOW.Inftrastructure.Tests.DbFixture;
using FluentAssertions;
using static EF.UOW.Inftrastructure.ContextOne.RepositoryOne;

namespace EF.UOW.Inftrastructure.Tests.PreRequisites;
public class BasicFeatures
{
    private readonly FirstDbContext firstDbContext;
    public BasicFeatures()
    {
        Fixture.CleanUpAllContexts();
        firstDbContext = Fixture.CreateFirstDbc();
    }

    [Fact]
    public void TablesShouldStartEmpty()
    {
        
        firstDbContext.T1.AsEnumerable().Should().BeEmpty();
    }

    [Fact]
    public void ShouldAddToT1() {

        RepositoryOne sut = new (firstDbContext);
        EntityOne entityOne=new();
        sut.Add(entityOne);
        firstDbContext.SaveChanges();
        firstDbContext.T1.Single().Should().BeEquivalentTo(entityOne);
    }

    [Fact]
    public void ShouldAddToT2()
    {
        
        RepositoryTwo sut = new RepositoryTwo(firstDbContext);
        EntityTwo entityTwo = new ();
        sut.Add(entityTwo);
        firstDbContext.SaveChanges();
        firstDbContext.T2.Single().Should().BeEquivalentTo(entityTwo);
    }


}
