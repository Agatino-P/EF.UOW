using EF.UOW.Inftrastructure.ContextOne;
using EF.UOW.Inftrastructure.Tests.DbFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EF.UOW.Inftrastructure.Tests.Transaction;
public class TransactionTests
{
    private readonly FirstDbContext firstDbContext;
    private readonly ITestOutputHelper output;

    public TransactionTests(ITestOutputHelper output)
    {
        Fixture.CleanUpAllContexts();
        firstDbContext = Fixture.CreateFirstDbc();
        this.output = output;
    }

    [Fact]
    public void ShouldRollBackAfterSaveChanges()
    {
        try
        {
            using (var transaction = firstDbContext.Database.BeginTransaction())
            {

                RepositoryOne sut = new(firstDbContext);
                EntityOne entityOne = new EntityOne();
                sut.Add(entityOne);

                throw new NotImplementedException();
                transaction.Commit();
            }

        }
        catch (Exception)
        {
            output.WriteLine("ExceptionHappned");
            FirstDbContext aDifferentFirstDbContext = Fixture.CreateFirstDbc();
            aDifferentFirstDbContext.T1.AsEnumerable().Should().BeEmpty();

        }
    }

}
