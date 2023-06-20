using System;
using Volo.Abp.EventBus;

namespace DotNetCoreStudy.Authors
{
    [EventName("RabbitMqTest")]
    public class StockCountChangedEto
    {
        public Guid ProductId { get; set; }

        public int NewCount { get; set; }
    }
}
