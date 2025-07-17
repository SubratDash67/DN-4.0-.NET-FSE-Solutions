
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaWinChat
{
    public partial class Form1 : Form
    {
        private IProducer<Null, string> producer;
        private IConsumer<Ignore, string> consumer;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            InitializeKafka();
        }

        private void InitializeKafka()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
            producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "win-chat-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
            cancellationTokenSource = new CancellationTokenSource();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            var message = textBox1.Text.Trim();
            try
            {
                var chatMessage = $"User_{Guid.NewGuid().ToString().Substring(0, 4)}: {message}";
                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = chatMessage });
                textBox1.Clear();
            }
            catch (ProduceException<Null, string> ex)
            {
                MessageBox.Show($"Delivery failed: {ex.Error.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kafka Chat Client";
            StartConsumer();
        }

        private void StartConsumer()
        {
            consumer.Subscribe("chat-topic");

            Task.Run(() =>
            {
                try
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cancellationTokenSource.Token);
                            if (consumeResult?.Message?.Value != null)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (!this.IsDisposed && listBox1 != null)
                                    {
                                        listBox1.Items.Add(consumeResult.Message.Value);
                                        if (listBox1.Items.Count > 0)
                                        {
                                            listBox1.TopIndex = listBox1.Items.Count - 1;
                                        }
                                    }
                                });
                            }
                        }
                        catch (ConsumeException ex)
                        {
                            if (!cancellationTokenSource.IsCancellationRequested)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show($"Consumer error: {ex.Error.Reason}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                });
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    if (!cancellationTokenSource.IsCancellationRequested)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show($"Unexpected consumer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                cancellationTokenSource?.Cancel();

                Task.Run(async () =>
                {
                    await Task.Delay(100);

                    producer?.Dispose();

                    consumer?.Close();
                    consumer?.Dispose();

                    cancellationTokenSource?.Dispose();
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }
    }
}
