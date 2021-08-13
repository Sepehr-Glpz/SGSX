using Microsoft.EntityFrameworkCore;
namespace SGSX.Persistense.Tools
{
    public static class Utility
    {

        public static void ConfigureDbContext(this Microsoft.EntityFrameworkCore.DbContextOptionsBuilder builder, Options options)
        {
            if(options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }

            var connectionString = options.ConnectionString ?? throw new System.NullReferenceException(nameof(options.ConnectionString));
            var provider = options.Provider;

			switch (provider)
			{
				case Enums.Provider.SqlServer:
					{
						builder.UseSqlServer
							(connectionString: connectionString);

						break;
					}

				case Enums.Provider.MySql:
					{
						//optionsBuilder.UseMySql
						//	(connectionString: connectionString);

						break;
					}

				case Enums.Provider.Oracle:
					{
						//optionsBuilder.UseOracle
						//	(connectionString: connectionString);

						break;
					}

				case Enums.Provider.PostgreSQL:
					{
						//optionsBuilder.UsePostgreSQL
						//	(connectionString: connectionString);

						break;
					}

				case Enums.Provider.InMemory:
					{
						//optionsBuilder.UseInMemoryDatabase
						//	(databaseName: "Db-Test");

						break;
					}

				default:
					{
						throw new System.ArgumentOutOfRangeException(nameof(provider));
					}
			}

		}

    }
}
