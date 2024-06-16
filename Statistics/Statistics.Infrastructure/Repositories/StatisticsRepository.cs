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

        if (statistics == null)
        {
            statistics = new TotalStatistics();
            await Data.AddAsync(statistics);
        }
        
        statistics.IncrementTotalOrders();

        await Save(statistics, cancellationToken);
    }

    public async Task IncrementProducts(CancellationToken cancellationToken = default)
    {
        var statistics = await Data
            .TotalStatistics
            .SingleOrDefaultAsync(cancellationToken);

        if (statistics == null)
        {
            statistics = new TotalStatistics();
            await Data.AddAsync(statistics);
        }
        
        statistics.IncrementTotalProducts();

        await Save(statistics, cancellationToken);
    }
}