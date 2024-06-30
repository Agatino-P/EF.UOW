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
    public void ShouldAddToT1()
    {

        RepositoryOne sut = new(firstDbContext);
        EntityOne entityOne = new();
        sut.Add(entityOne);

        FirstDbContext aDifferentFirstDbContext = Fixture.CreateFirstDbc();
        aDifferentFirstDbContext.T1.Single().Should().BeEquivalentTo(entityOne);
    }

    [Fact]
    public void ShouldAddToT2()
    {

        RepositoryTwo sut = new RepositoryTwo(firstDbContext);
        EntityTwo entityTwo = new();
        sut.Add(entityTwo);
        firstDbContext.SaveChanges();
        firstDbContext.T2.Single().Should().BeEquivalentTo(entityTwo);
    }

    [Fact]
    public void ShouldRollbackOnExceptionSingleTable()
    {
        EntityOne entityOne = new(Guid.Parse("c8b4919a-117a-4e18-8096-c48e337c6335"));

        RepositoryOne sut = new(firstDbContext);
        Action createExc = ()=>  sut.CauseException(entityOne);
        createExc.Should().Throw<Exception>();

        FirstDbContext aDifferentFirstDbContext = Fixture.CreateFirstDbc();
        aDifferentFirstDbContext.T1.AsEnumerable().Should().BeEmpty();
    }

}
