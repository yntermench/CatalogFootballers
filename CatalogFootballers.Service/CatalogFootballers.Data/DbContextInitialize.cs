namespace CatalogFootballers.Data
{
    /// <summary>
    /// The class responsible for initializing the Database.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Initialize Database <see cref="CatalogFootballersDbContext"/>.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(CatalogFootballersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
