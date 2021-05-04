using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MSP.BetterCalm.DataAccess
{
    public enum ContextType { MEMORY, SQL }

    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return GetNewContext();
        }

        public static DataContext GetNewContext(ContextType type = ContextType.SQL)
        {
            var builder = new DbContextOptionsBuilder<DataContext>();
            DbContextOptions options = null;
            if (type == ContextType.MEMORY)
            {
                options = GetMemoryConfig(builder);
            }
            else
            {
                options = GetSqlConfig(builder);
            }

            return new DataContext(options);
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("BetterCalmDB");

            return builder.Options;
        }

        private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder)
        {
            //TODO: Se puede mejorar esto colocando en un archivo externo y obteniendo
            // desde allí la información.
            builder.UseSqlServer(@"Server=LAPTOP-9P85EPU1\SQLEXPRESS;Database=MSPBetterCalmDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            return builder.Options;
        }
    }
}