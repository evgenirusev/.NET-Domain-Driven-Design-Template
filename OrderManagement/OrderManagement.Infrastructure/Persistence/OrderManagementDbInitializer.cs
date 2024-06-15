internal class OrderManagementDbInitializer : DbInitializer
{
    public OrderManagementDbInitializer(
        OrderManagementDbContext db,
        IEnumerable<IInitialData> initialDataProviders)
        : base(db, initialDataProviders)
    {
    }
}