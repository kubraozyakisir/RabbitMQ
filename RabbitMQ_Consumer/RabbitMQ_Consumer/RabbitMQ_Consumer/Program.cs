
//bağlantı oluşturma
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://qoxhlkik:yO2iEwKJ9VcxsAOHpV9cHKtAjPgK5O5D@gull.rmq.cloudamqp.com/qoxhlkik");

//Bağlantı aktifleştirme ve kanal açma
using IConnection connection =  factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue oluşturma
channel.QueueDeclare(queue:"example-queue",exclusive:false);
//consumer'da kuyruk, publisher'daki ile birebir aynı yapılandırmada tanımlanmalıdır.

//Queue'dan mesaj okuma
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue:"example-queue",false,consumer);
consumer.Received += (sender, e) =>
{
    //kuyruğa gelen mesajın işlendiği yerdir
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));

};
Console.Read();