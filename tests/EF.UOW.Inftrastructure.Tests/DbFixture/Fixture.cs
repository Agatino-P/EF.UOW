using EF.UOW.Inftrastructure.ContextOne;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.UOW.Inftrastructure.Tests.DbFixture;
public class Fixture
{
    public const string ConnectionString = "Server=localhost;Database=db1;User Id=sa;Password=P@ssword01;TrustServerCertificate=True;";

    public static void CleanUpAllContexts()
    {
        const string sqlString = @"
            TRUNCATE TABLE dbo.t1;
            TRUNCATE TABLE dbo.t2;
        ";
        using FirstDbContext firstDbContext = CreateFirstDbc();
        firstDbContext.Database.ExecuteSqlRaw(sqlString);
    }

    public static FirstDbContext CreateFirstDbc() => new(ConnectionString);

}
