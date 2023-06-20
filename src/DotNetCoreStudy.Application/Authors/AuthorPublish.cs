using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace DotNetCoreStudy.Authors
{
    public class AuthorPublish : ITransientDependency
    {
        private readonly IDistributedEventBus _distributedEventBus;

        public AuthorPublish(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public virtual async Task ChangeStockCountAsync(Guid productId, int newCount)
        {
            await _distributedEventBus.PublishAsync(
                    new StockCountChangedEto
                    {
                        ProductId = productId,
                        NewCount = newCount
                    }
                );
        }
    }
}
