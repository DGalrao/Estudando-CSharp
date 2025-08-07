using Confluent.Kafka;

namespace Infrastructure
{
    public class KafkaConsumer
    {
        private readonly IConsumer<Null, string> _consumer;

        public KafkaConsumer(string bootstrapServers, string groupId)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Null, string>(config).Build();
        }

        public void Consume(string topic)
        {
            _consumer.Subscribe(topic);
            while (true)
            {
                var cr = _consumer.Consume();
                Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
            }
        }
    }
}
