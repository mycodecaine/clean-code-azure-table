using Azure.Data.Tables;
using Azure;

namespace Cdcn.Domain.Core.Primitives
{
    public class Entity : ITableEntity
    {
        public Entity(string partion)
        {
            PartitionKey = partion;
            Timestamp = DateTime.Now;
            RowKey = Guid.NewGuid().ToString();
            ETag = ETag.All;
        }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        public Guid Id => Guid.Parse(RowKey);
    }
}
