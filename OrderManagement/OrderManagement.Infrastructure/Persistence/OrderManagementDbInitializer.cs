internal class OrderManagementDbInitializer : DbInitializer
{
    public OrderManagementDbInitializer(
        OrderManagementDbContext db)
        : base(db, new List<IInitialData>())
    {
    }
}