using AutoMapper;
using Microsoft.EntityFrameworkCore;

internal class StatisticsRepository : DataRepository<StatisticsDbContext, TotalStatistics>,
    IStatisticsDomainRepository,
    IStatisticsQueryRepository
{
    private readonly IMapper mapper;

    public StatisticsRepository(StatisticsDbContext db, IMapper mapper)
        : base(db)
        => this.mapper = mapper;

    public async Task IncrementOrders(CancellationToken cancellationToken = default)
    {
        var statistics = await Data
            .TotalStatistics
            .SingleOrDefaultAsync(cancellationToken);

        // TODO: Create statistics using DataInitializer and remove this condition
        if (statistics == null)
        {
            return;
        }
        
        statistics.IncrementTotalOrders();
        
        await Save(statistics, cancellationToken);
    }

    public async Task IncrementProducts(CancellationToken cancellationToken = default)
    {
        var statistics = await Data
            .TotalStatistics
            .SingleOrDefaultAsync(cancellationToken);

        // TODO: Create statistics using DataInitializer and remove this condition
        if (statistics == null)
        {
            return;
        }
        
        statistics.IncrementTotalProducts();
        
        await Save(statistics, cancellationToken);
    }
}